using System;
using System.Linq;
using System.Windows.Forms;

namespace TestApp
{
    public partial class EmployeeInfoEditForm : Form
    {
        private readonly decimal _employeeId;
        private readonly Guid?   _selectedDepartmentId;

        public EmployeeInfoEditForm(Guid? id = null, decimal employeeId = -1)
        {
            InitializeComponent();
            _selectedDepartmentId = id;
            _employeeId           = employeeId;
        }

        private void EmployeeInfoEdit_Load(object sender, EventArgs e)
        {
            GlobalVars.Log.Info("EmployeeInfoEdit: Загрузка информации о сотруднике");
            using (var db = new TestDBEntities())
            {
                var departments = db.Department.ToList();

                foreach (var department in departments)
                    ComboBox_Department.Items.Add($"{department.Code} / {department.Name}");

                if (_employeeId != -1)
                {
                    var employee = db.Empoyee.First(x => x.ID == _employeeId);
                    TextBox_FirstName.Text            = employee.FirstName;
                    TextBox_SurName.Text              = employee.SurName;
                    TextBox_Patronymic.Text           = employee.Patronymic;
                    DateTimePicker_BirthDate.Value    = employee.DateOfBirth;
                    TextBox_DocSeries.Text            = employee.DocSeries;
                    TextBox_DocNumber.Text            = employee.DocNumber;
                    TextBox_Position.Text             = employee.Position;
                    ComboBox_Department.SelectedIndex = departments.FindIndex(x => x.ID == employee.DepartmentID);
                }
                else if (_selectedDepartmentId != null)
                    ComboBox_Department.SelectedIndex = departments.FindIndex(x => x.ID == _selectedDepartmentId);
                else
                    ComboBox_Department.SelectedIndex = -1;
            }
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            GlobalVars.Log.Info("EmployeeInfoEdit: Сохранение информации о сотруднике");
            if (TextBox_FirstName.Text            == ""
             || TextBox_SurName.Text              == ""
             || TextBox_Position.Text             == ""
             || ComboBox_Department.SelectedIndex == -1)
            {
                MessageBox.Show("Не все обязательные поля заполнены!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (DateTimePicker_BirthDate.Value > DateTime.Now)
            {
                MessageBox.Show("Дата рождения не может быть больше текущей даты!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (var db = new TestDBEntities())
                    {
                        var departments = db.Department.ToList();

                        if (_employeeId == -1)
                        {
                            db.Empoyee.Add(new Empoyee
                            {
                                FirstName    = TextBox_FirstName.Text,
                                SurName      = TextBox_SurName.Text,
                                Patronymic   = TextBox_Patronymic.Text,
                                DateOfBirth  = DateTimePicker_BirthDate.Value,
                                DocSeries    = TextBox_DocSeries.Text,
                                DocNumber    = TextBox_DocNumber.Text,
                                Position     = TextBox_Position.Text,
                                DepartmentID = departments[ComboBox_Department.SelectedIndex].ID
                            });
                        }
                        else
                        {
                            var employee = db.Empoyee.First(x => x.ID == _employeeId);
                            employee.FirstName    = TextBox_FirstName.Text;
                            employee.SurName      = TextBox_SurName.Text;
                            employee.Patronymic   = TextBox_Patronymic.Text;
                            employee.DateOfBirth  = DateTimePicker_BirthDate.Value;
                            employee.DocSeries    = TextBox_DocSeries.Text;
                            employee.DocNumber    = TextBox_DocNumber.Text;
                            employee.Position     = TextBox_Position.Text;
                            employee.DepartmentID = departments[ComboBox_Department.SelectedIndex].ID;
                        }

                        db.SaveChanges();
                    }

                    this.Close();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    GlobalVars.Log.Info(ex, "EmployeeInfoEdit: Ошибка при сохранении информации о сотруднике");
                    MessageBox.Show($"Возникла ошибка. Возможно некоторые поля заполнены неправильно.\n\n{ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage}", "Error",
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