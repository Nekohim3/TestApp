namespace TestApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TreeView_Departments = new System.Windows.Forms.TreeView();
            this.Button_ExpandAllTreeView = new System.Windows.Forms.Button();
            this.Button_CollapseAllTreeView = new System.Windows.Forms.Button();
            this.GroupBox_SelectedDepartmentInfo = new System.Windows.Forms.GroupBox();
            this.Label_DepartmentInfoName = new System.Windows.Forms.Label();
            this.Label_DepartmentInfoCodeName = new System.Windows.Forms.Label();
            this.Label_DepartmentInfoID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGridView_Employers = new System.Windows.Forms.DataGridView();
            this.GroupBox_Employers = new System.Windows.Forms.GroupBox();
            this.Button_EditEmployee = new System.Windows.Forms.Button();
            this.Button_RemoveEmployee = new System.Windows.Forms.Button();
            this.Button_AddEmployee = new System.Windows.Forms.Button();
            this.Button_DeleteDepartment = new System.Windows.Forms.Button();
            this.Button_EditDepartment = new System.Windows.Forms.Button();
            this.Button_AddDepartment = new System.Windows.Forms.Button();
            this.GroupBox_SelectedDepartmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Employers)).BeginInit();
            this.GroupBox_Employers.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView_Departments
            // 
            this.TreeView_Departments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TreeView_Departments.Location = new System.Drawing.Point(12, 41);
            this.TreeView_Departments.Name = "TreeView_Departments";
            this.TreeView_Departments.Size = new System.Drawing.Size(303, 575);
            this.TreeView_Departments.TabIndex = 0;
            this.TreeView_Departments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_Departments_AfterSelect);
            // 
            // Button_ExpandAllTreeView
            // 
            this.Button_ExpandAllTreeView.Location = new System.Drawing.Point(12, 12);
            this.Button_ExpandAllTreeView.Name = "Button_ExpandAllTreeView";
            this.Button_ExpandAllTreeView.Size = new System.Drawing.Size(100, 23);
            this.Button_ExpandAllTreeView.TabIndex = 1;
            this.Button_ExpandAllTreeView.Text = "Развернуть все";
            this.Button_ExpandAllTreeView.UseVisualStyleBackColor = true;
            this.Button_ExpandAllTreeView.Click += new System.EventHandler(this.Button_ExpandAllTreeView_Click);
            // 
            // Button_CollapseAllTreeView
            // 
            this.Button_CollapseAllTreeView.Location = new System.Drawing.Point(118, 12);
            this.Button_CollapseAllTreeView.Name = "Button_CollapseAllTreeView";
            this.Button_CollapseAllTreeView.Size = new System.Drawing.Size(92, 23);
            this.Button_CollapseAllTreeView.TabIndex = 2;
            this.Button_CollapseAllTreeView.Text = "Свернуть все";
            this.Button_CollapseAllTreeView.UseVisualStyleBackColor = true;
            this.Button_CollapseAllTreeView.Click += new System.EventHandler(this.Button_CollapseAllTreeView_Click);
            // 
            // GroupBox_SelectedDepartmentInfo
            // 
            this.GroupBox_SelectedDepartmentInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox_SelectedDepartmentInfo.Controls.Add(this.Button_EditDepartment);
            this.GroupBox_SelectedDepartmentInfo.Controls.Add(this.Button_DeleteDepartment);
            this.GroupBox_SelectedDepartmentInfo.Controls.Add(this.Label_DepartmentInfoName);
            this.GroupBox_SelectedDepartmentInfo.Controls.Add(this.Label_DepartmentInfoCodeName);
            this.GroupBox_SelectedDepartmentInfo.Controls.Add(this.Label_DepartmentInfoID);
            this.GroupBox_SelectedDepartmentInfo.Controls.Add(this.label3);
            this.GroupBox_SelectedDepartmentInfo.Controls.Add(this.label2);
            this.GroupBox_SelectedDepartmentInfo.Controls.Add(this.label1);
            this.GroupBox_SelectedDepartmentInfo.Location = new System.Drawing.Point(321, 12);
            this.GroupBox_SelectedDepartmentInfo.Name = "GroupBox_SelectedDepartmentInfo";
            this.GroupBox_SelectedDepartmentInfo.Size = new System.Drawing.Size(838, 72);
            this.GroupBox_SelectedDepartmentInfo.TabIndex = 3;
            this.GroupBox_SelectedDepartmentInfo.TabStop = false;
            this.GroupBox_SelectedDepartmentInfo.Text = "Информаци о выбранном отделе";
            // 
            // Label_DepartmentInfoName
            // 
            this.Label_DepartmentInfoName.AutoSize = true;
            this.Label_DepartmentInfoName.Location = new System.Drawing.Point(113, 48);
            this.Label_DepartmentInfoName.Name = "Label_DepartmentInfoName";
            this.Label_DepartmentInfoName.Size = new System.Drawing.Size(0, 13);
            this.Label_DepartmentInfoName.TabIndex = 5;
            // 
            // Label_DepartmentInfoCodeName
            // 
            this.Label_DepartmentInfoCodeName.AutoSize = true;
            this.Label_DepartmentInfoCodeName.Location = new System.Drawing.Point(113, 32);
            this.Label_DepartmentInfoCodeName.Name = "Label_DepartmentInfoCodeName";
            this.Label_DepartmentInfoCodeName.Size = new System.Drawing.Size(0, 13);
            this.Label_DepartmentInfoCodeName.TabIndex = 4;
            // 
            // Label_DepartmentInfoID
            // 
            this.Label_DepartmentInfoID.AutoSize = true;
            this.Label_DepartmentInfoID.Location = new System.Drawing.Point(113, 16);
            this.Label_DepartmentInfoID.Name = "Label_DepartmentInfoID";
            this.Label_DepartmentInfoID.Size = new System.Drawing.Size(0, 13);
            this.Label_DepartmentInfoID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Кодовое название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // DataGridView_Employers
            // 
            this.DataGridView_Employers.AllowUserToAddRows = false;
            this.DataGridView_Employers.AllowUserToDeleteRows = false;
            this.DataGridView_Employers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Employers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Employers.Location = new System.Drawing.Point(6, 19);
            this.DataGridView_Employers.Name = "DataGridView_Employers";
            this.DataGridView_Employers.ReadOnly = true;
            this.DataGridView_Employers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Employers.Size = new System.Drawing.Size(826, 472);
            this.DataGridView_Employers.TabIndex = 4;
            // 
            // GroupBox_Employers
            // 
            this.GroupBox_Employers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox_Employers.Controls.Add(this.Button_EditEmployee);
            this.GroupBox_Employers.Controls.Add(this.Button_RemoveEmployee);
            this.GroupBox_Employers.Controls.Add(this.Button_AddEmployee);
            this.GroupBox_Employers.Controls.Add(this.DataGridView_Employers);
            this.GroupBox_Employers.Location = new System.Drawing.Point(321, 90);
            this.GroupBox_Employers.Name = "GroupBox_Employers";
            this.GroupBox_Employers.Size = new System.Drawing.Size(838, 526);
            this.GroupBox_Employers.TabIndex = 5;
            this.GroupBox_Employers.TabStop = false;
            this.GroupBox_Employers.Text = "Список сотрудников отдела";
            // 
            // Button_EditEmployee
            // 
            this.Button_EditEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_EditEmployee.Location = new System.Drawing.Point(154, 497);
            this.Button_EditEmployee.Name = "Button_EditEmployee";
            this.Button_EditEmployee.Size = new System.Drawing.Size(155, 23);
            this.Button_EditEmployee.TabIndex = 8;
            this.Button_EditEmployee.Text = "Редактировать сотрудника";
            this.Button_EditEmployee.UseVisualStyleBackColor = true;
            this.Button_EditEmployee.Click += new System.EventHandler(this.Button_EditEmployee_Click);
            // 
            // Button_RemoveEmployee
            // 
            this.Button_RemoveEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_RemoveEmployee.Location = new System.Drawing.Point(315, 497);
            this.Button_RemoveEmployee.Name = "Button_RemoveEmployee";
            this.Button_RemoveEmployee.Size = new System.Drawing.Size(129, 23);
            this.Button_RemoveEmployee.TabIndex = 7;
            this.Button_RemoveEmployee.Text = "Удалить сотрудника";
            this.Button_RemoveEmployee.UseVisualStyleBackColor = true;
            this.Button_RemoveEmployee.Click += new System.EventHandler(this.Button_RemoveEmployee_Click);
            // 
            // Button_AddEmployee
            // 
            this.Button_AddEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_AddEmployee.Location = new System.Drawing.Point(6, 497);
            this.Button_AddEmployee.Name = "Button_AddEmployee";
            this.Button_AddEmployee.Size = new System.Drawing.Size(142, 23);
            this.Button_AddEmployee.TabIndex = 6;
            this.Button_AddEmployee.Text = "Добавить сотрудника";
            this.Button_AddEmployee.UseVisualStyleBackColor = true;
            this.Button_AddEmployee.Click += new System.EventHandler(this.Button_AddEmployee_Click);
            // 
            // Button_DeleteDepartment
            // 
            this.Button_DeleteDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DeleteDepartment.Location = new System.Drawing.Point(708, 41);
            this.Button_DeleteDepartment.Name = "Button_DeleteDepartment";
            this.Button_DeleteDepartment.Size = new System.Drawing.Size(124, 23);
            this.Button_DeleteDepartment.TabIndex = 6;
            this.Button_DeleteDepartment.Text = "Удалить отдел";
            this.Button_DeleteDepartment.UseVisualStyleBackColor = true;
            this.Button_DeleteDepartment.Click += new System.EventHandler(this.Button_DeleteDepartment_Click);
            // 
            // Button_EditDepartment
            // 
            this.Button_EditDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_EditDepartment.Location = new System.Drawing.Point(708, 13);
            this.Button_EditDepartment.Name = "Button_EditDepartment";
            this.Button_EditDepartment.Size = new System.Drawing.Size(124, 23);
            this.Button_EditDepartment.TabIndex = 7;
            this.Button_EditDepartment.Text = "Редактировать отдел";
            this.Button_EditDepartment.UseVisualStyleBackColor = true;
            this.Button_EditDepartment.Click += new System.EventHandler(this.Button_EditDepartment_Click);
            // 
            // Button_AddDepartment
            // 
            this.Button_AddDepartment.Location = new System.Drawing.Point(216, 12);
            this.Button_AddDepartment.Name = "Button_AddDepartment";
            this.Button_AddDepartment.Size = new System.Drawing.Size(99, 23);
            this.Button_AddDepartment.TabIndex = 6;
            this.Button_AddDepartment.Text = "Добавить отдел";
            this.Button_AddDepartment.UseVisualStyleBackColor = true;
            this.Button_AddDepartment.Click += new System.EventHandler(this.Button_AddDepartment_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 628);
            this.Controls.Add(this.Button_AddDepartment);
            this.Controls.Add(this.GroupBox_Employers);
            this.Controls.Add(this.GroupBox_SelectedDepartmentInfo);
            this.Controls.Add(this.Button_CollapseAllTreeView);
            this.Controls.Add(this.Button_ExpandAllTreeView);
            this.Controls.Add(this.TreeView_Departments);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Form1";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GroupBox_SelectedDepartmentInfo.ResumeLayout(false);
            this.GroupBox_SelectedDepartmentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Employers)).EndInit();
            this.GroupBox_Employers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView_Departments;
        private System.Windows.Forms.Button Button_ExpandAllTreeView;
        private System.Windows.Forms.Button Button_CollapseAllTreeView;
        private System.Windows.Forms.GroupBox GroupBox_SelectedDepartmentInfo;
        private System.Windows.Forms.Label Label_DepartmentInfoName;
        private System.Windows.Forms.Label Label_DepartmentInfoCodeName;
        private System.Windows.Forms.Label Label_DepartmentInfoID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGridView_Employers;
        private System.Windows.Forms.GroupBox GroupBox_Employers;
        private System.Windows.Forms.Button Button_EditEmployee;
        private System.Windows.Forms.Button Button_RemoveEmployee;
        private System.Windows.Forms.Button Button_AddEmployee;
        private System.Windows.Forms.Button Button_EditDepartment;
        private System.Windows.Forms.Button Button_DeleteDepartment;
        private System.Windows.Forms.Button Button_AddDepartment;
    }
}

