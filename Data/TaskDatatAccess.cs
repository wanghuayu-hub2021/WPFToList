using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFToDoList.Model;

namespace WPFToDoList.Data
{
    public enum OptionType
    {
        offlineType = 0,
        onLineType = 1
    }
    /// <summary>
    /// 数据访问层
    /// </summary>
    public class TaskDatatAccess
    {
        public XmlConfig xmlConfig = new XmlConfig();

        public List<TaskModel> GetTaskData(OptionType optionType)
        {
            List<TaskModel> taskData = new List<TaskModel>();
            if (optionType == OptionType.offlineType)
            {
                return xmlConfig.GetDataFromXml("/Common/TaskData.xml");
            }
            else
            {
                TaskModel task = new TaskModel
                {
                    TaskDescription = "Main Task Description",
                    TaskId = "T100",
                    TaskStatus = "0",
                    TaskType = "1",
                    CompletionDate = "2024-06-30",
                    EndDate = "2024-07-01",
                    StartDate = "2024-06-20",
                    IsRecurring = "0",
                    Tags = "Important, Urgent"
                };

                // 为子任务列表添加子任务
                SubTaskModel subTask1 = new SubTaskModel
                {
                    SubTaskDescription = "Sub Task 1 Description",
                    SubTaskId = "ST101",
                    TaskId = task.TaskId, // 确保子任务的TaskId与父任务的TaskId一致
                    SubTaskStatus = "0",
                    StartDate = "2024-06-21",
                    EndDate = "2024-06-23",
                    CompletionDate = "2024-06-24",
                    IsRecurring = "0"
                };
                SubTaskModel subTask2 = new SubTaskModel
                {
                    SubTaskDescription = "Sub Task 2 Description",
                    SubTaskId = "ST102",
                    TaskId = task.TaskId, // 确保子任务的TaskId与父任务的TaskId一致
                    SubTaskStatus = "0",
                    StartDate = "2024-06-21",
                    EndDate = "2024-06-23",
                    CompletionDate = "2024-06-24",
                    IsRecurring = "0"
                };
                SubTaskModel subTask3 = new SubTaskModel
                {
                    SubTaskDescription = "Sub Task 3 Description",
                    SubTaskId = "ST103",
                    TaskId = task.TaskId, // 确保子任务的TaskId与父任务的TaskId一致
                    SubTaskStatus = "0",
                    StartDate = "2024-06-21",
                    EndDate = "2024-06-23",
                    CompletionDate = "2024-06-24",
                    IsRecurring = "0"
                };

                task.SubTasks.Add(subTask1);
                task.SubTasks.Add(subTask2);
                task.SubTasks.Add(subTask3);
            }
            return new List<TaskModel>();
        }

    }
}
