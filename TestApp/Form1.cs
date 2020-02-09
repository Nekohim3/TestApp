using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var e = args.ExceptionObject as Exception;

                var exStr =
                    $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}\nUnhandledException\n\nMessage:\n{e?.Message}\n\nInnerExceprionMessage:\n{e?.InnerException?.Message}\n\nSource:\n{e?.Source}\n\nStackTrace:\n{e?.StackTrace}\n\n\n";

                using (var fs = new FileStream("Exception.txt", FileMode.Append, FileAccess.Write))
                using (var sw = new StreamWriter(fs))
                    sw.Write(exStr);

                if (args.ExceptionObject is System.Data.Entity.Core.EntityException)
                {
                    MessageBox.Show("Не удалось установить соединение с базой данных. Приложение будет закрыто.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (false)
                {
                    //other exceptions
                }
                else
                {
                    MessageBox.Show("Возникла непредвиденная ошибка! Приложение будет закрыто. Детали находятся в файле Exception.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Process.GetCurrentProcess().Kill();
            };

            InitializeComponent();
        }

        private void FillDepartmentsChildTreeView(TreeNode node, Department dep)
        {
            foreach (var childDepartment in dep.ChildDepartaments)
            {
                var childNode = new TreeNode($"{childDepartment.Code} / {childDepartment.Name}") {Name = childDepartment.ID.ToString()};
                node.Nodes.Add(childNode);
                FillDepartmentsChildTreeView(childNode, childDepartment);
            }
        }

        private void FillDepartmentsTreeView()
        {
            TreeView_Departments.Nodes.Clear();

            using (var db = new TestDBEntities())
            {
                var rootDepartments = db.Department.Where(x => x.ParentDepartmentID == null);

                foreach (var rootDepartment in rootDepartments)
                {
                    var rootNode = new TreeNode($"{rootDepartment.Code} / {rootDepartment.Name}") {Name = rootDepartment.ID.ToString()};
                    TreeView_Departments.Nodes.Add(rootNode);
                    FillDepartmentsChildTreeView(rootNode, rootDepartment);
                }
            }

            Label_DepartmentInfoID.Text       = "";
            Label_DepartmentInfoName.Text     = "";
            Label_DepartmentInfoCodeName.Text = "";
            Button_DeleteDepartment.Enabled   = false;
            Button_EditDepartment.Enabled     = false;
            DataGridView_Employers.DataSource = null;
            DataGridView_Employers.Columns.Clear();
        }

        private void FillDataGridViewEmployers()
        {
            var selectedDepartmentId = new Guid(TreeView_Departments.SelectedNode.Name);

            using (var db = new TestDBEntities())
            {
                var department = db.Department.First(x => x.ID == selectedDepartmentId);
                Label_DepartmentInfoID.Text       = department.ID.ToString();
                Label_DepartmentInfoName.Text     = department.Name;
                Label_DepartmentInfoCodeName.Text = department.Code;
                Button_DeleteDepartment.Enabled   = true;
                Button_EditDepartment.Enabled     = true;

                DataGridView_Employers.DataSource                      = db.Empoyee.Where(x => x.DepartmentID == selectedDepartmentId).ToList();
                DataGridView_Employers.Columns["Department"].Visible   = false;
                DataGridView_Employers.Columns["DepartmentID"].Visible = false;

                if (DataGridView_Employers.Columns["Age"] == null)
                    DataGridView_Employers.Columns.Add("Age", "Age");

                foreach (DataGridViewRow row in DataGridView_Employers.Rows)
                    row.Cells["Age"].Value = new DateTime(DateTime.Now.Subtract(Convert.ToDateTime(row.Cells["DateOfBirth"].Value.ToString())).Ticks).Year - 1;

                foreach (DataGridViewColumn column in DataGridView_Employers.Columns)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void RecursiveDeleteDepartmentEmployers(List<Department> departmentlist, Department department, TestDBEntities db)
        {
            foreach (var childDepartament in department.ChildDepartaments)
                RecursiveDeleteDepartmentEmployers(departmentlist, childDepartament, db);

            db.Empoyee.RemoveRange(db.Empoyee.Where(x => x.DepartmentID == department.ID));
            departmentlist.Add(department);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDepartmentsTreeView();
        }

        private void Button_ExpandAllTreeView_Click(object sender, EventArgs e)
        {
            TreeView_Departments.ExpandAll();
        }

        private void Button_CollapseAllTreeView_Click(object sender, EventArgs e)
        {
            TreeView_Departments.CollapseAll();
        }

        private void TreeView_Departments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FillDataGridViewEmployers();
        }

        private void Button_AddEmployee_Click(object sender, EventArgs e)
        {
            Guid? selectedDepartmentId = null;

            if (TreeView_Departments.SelectedNode != null)
            {
                selectedDepartmentId = new Guid(TreeView_Departments.SelectedNode.Name);
            }

            var form = new EmployeeInfoEditForm(id: selectedDepartmentId) {Owner = this};
            form.ShowDialog();
            FillDataGridViewEmployers();
        }

        private void Button_EditEmployee_Click(object sender, EventArgs e)
        {
            if (DataGridView_Employers.SelectedRows.Count != 0)
            {
                var selectedRowIndex = DataGridView_Employers.CurrentRow.Index;
                var employeeId       = Convert.ToDecimal(DataGridView_Employers.SelectedRows[0].Cells["ID"].Value);
                var form             = new EmployeeInfoEditForm(employeeId: employeeId) {Owner = this};
                form.ShowDialog();
                FillDataGridViewEmployers();

                foreach (DataGridViewRow row in DataGridView_Employers.Rows)
                    row.Selected = row.Index == selectedRowIndex;

                if (selectedRowIndex < DataGridView_Employers.RowCount)
                    DataGridView_Employers.CurrentCell = DataGridView_Employers.Rows[selectedRowIndex].Cells[0];
                else
                    DataGridView_Employers.CurrentCell = DataGridView_Employers.Rows[0].Cells[0];
            }
        }

        private void Button_RemoveEmployee_Click(object sender, EventArgs e)
        {
            if (DataGridView_Employers.SelectedRows.Count != 0)
            {
                var employeeId = Convert.ToDecimal(DataGridView_Employers.SelectedRows[0].Cells["ID"].Value);

                using (var db = new TestDBEntities())
                {
                    var employee = db.Empoyee.First(x => x.ID == employeeId);

                    if (MessageBox.Show($"Вы действительно хотите удалить сотрудника {employee.FirstName} {employee.SurName} {employee.Patronymic} из базы?",
                                        "Warning",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button2)
                     == DialogResult.Yes)
                    {
                        db.Empoyee.Remove(employee);
                        db.SaveChanges();
                        FillDataGridViewEmployers();
                    }
                }
            }
        }

        private void Button_AddDepartment_Click(object sender, EventArgs e)
        {
            var form = new DepartmentInfoEditForm {Owner = this};
            form.ShowDialog();
            FillDepartmentsTreeView();
        }

        private void Button_EditDepartment_Click(object sender, EventArgs e)
        {
            if (TreeView_Departments.SelectedNode != null)
            {
                var selectedDepartmentId = new Guid(TreeView_Departments.SelectedNode.Name);
                var form                 = new DepartmentInfoEditForm(selectedDepartmentId) {Owner = this};
                form.ShowDialog();
                FillDepartmentsTreeView();
            }
        }

        private void Button_DeleteDepartment_Click(object sender, EventArgs e)
        {
            using (var db = new TestDBEntities())
            {
                var selectedDepartmentId = new Guid(TreeView_Departments.SelectedNode.Name);
                var selectedDepartment   = db.Department.First(x => x.ID == selectedDepartmentId);

                if (MessageBox.Show($"Вы действительно хотите удалить отдел \"{selectedDepartment.Code} / {selectedDepartment.Name}\"",
                                    "Warning",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button2)
                 == DialogResult.Yes)
                {
                    var departmentsDorDelete = new List<Department>();
                    RecursiveDeleteDepartmentEmployers(departmentsDorDelete, selectedDepartment, db);
                    db.Department.RemoveRange(departmentsDorDelete);
                    db.SaveChanges();
                    FillDepartmentsTreeView();
                    DataGridView_Employers.DataSource = null;
                    DataGridView_Employers.Columns.Clear();
                }
            }
        }
    }
}