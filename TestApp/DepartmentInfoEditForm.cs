using System;
using System.Linq;
using System.Windows.Forms;

namespace TestApp
{
    public partial class DepartmentInfoEditForm : Form
    {
        private readonly Guid? _departmentId;

        public DepartmentInfoEditForm(Guid? id = null)
        {
            InitializeComponent();
            _departmentId = id;
        }

        private void DepartmentInfoEditForm_Load(object sender, EventArgs e)
        {
            using (var db = new TestDBEntities())
            {
                var departments = db.Department.ToList();

                ComboBox_ParentDepartment.Items.Add("Нет");

                foreach (var department in departments)
                    ComboBox_ParentDepartment.Items.Add($"{department.Code} / {department.Name}");

                ComboBox_ParentDepartment.SelectedIndex = 0;

                if (_departmentId != null)
                {
                    var department = db.Department.First(x => x.ID == _departmentId);
                    MaskedTextBox_ID.Text = department.ID.ToString();
                    TextBox_Name.Text     = department.Name;
                    TextBox_CodeName.Text = department.Code;

                    if (department.ParentDepartmentID != null)
                        ComboBox_ParentDepartment.SelectedIndex = departments.FindIndex(x => x.ID == department.ParentDepartmentID) + 1;
                }
                else
                    MaskedTextBox_ID.Text = Guid.NewGuid().ToString();
            }
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (MaskedTextBox_ID.Text == ""
             || TextBox_Name.Text     == "")
            {
                MessageBox.Show("Не все обязательные поля заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!Guid.TryParse(MaskedTextBox_ID.Text, out var res))
            {
                MessageBox.Show("Идентификатор введен неправильно!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ComboBox_ParentDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Отдела, выбранного в качестве родительского, не существует!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (var db = new TestDBEntities())
                    {
                        var departments = db.Department.ToList();

                        if (_departmentId == null)
                        {
                            var department = new Department
                            {
                                ID   = Guid.Parse(MaskedTextBox_ID.Text),
                                Code = TextBox_CodeName.Text,
                                Name = TextBox_Name.Text
                            };

                            if (ComboBox_ParentDepartment.SelectedIndex > 0)
                                department.ParentDepartmentID = departments[ComboBox_ParentDepartment.SelectedIndex - 1].ID;

                            db.Department.Add(department);
                        }
                        else
                        {
                            var department = db.Department.First(x => x.ID == _departmentId);
                            department.ID   = Guid.Parse(MaskedTextBox_ID.Text);
                            department.Code = TextBox_CodeName.Text;
                            department.Name = TextBox_Name.Text;

                            if (ComboBox_ParentDepartment.SelectedIndex > 0)
                                department.ParentDepartmentID = departments[ComboBox_ParentDepartment.SelectedIndex - 1].ID;
                            else
                                department.ParentDepartmentID = null;
                        }

                        db.SaveChanges();
                    }

                    this.Close();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException exception)
                {
                    MessageBox.Show($"Возникла ошибка. Возможно некоторые поля заполнены неправильно.\n\n{exception.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}