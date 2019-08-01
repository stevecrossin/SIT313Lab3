using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
namespace Lab3Task2
{
    public partial class ShowAllInfoController : UITableViewController
    {
        public List<StudentInfo> allStudents { get; set; }
        ///---------
        static NSString allStudentCellId = new NSString("allStudentCell");
        public ShowAllInfoController(IntPtr handle) : base(handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), allStudentCellId);
            TableView.Source = new AllStudentDataSource(this);
            allStudents = new List<StudentInfo>();
        }
        class AllStudentDataSource : UITableViewSource
        {
            ShowAllInfoController controller;
            public AllStudentDataSource(ShowAllInfoController controller)
            {
                this.controller = controller;
            }
            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return controller.allStudents.Count;
            }
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell =
                tableView.DequeueReusableCell(ShowAllInfoController.allStudentCellId);
                int row = indexPath.Row;
                cell.TextLabel.Text = controller.allStudents[row].name + " " + controller.allStudents[row].id; ;
                return cell;
            }
        }
    }
}