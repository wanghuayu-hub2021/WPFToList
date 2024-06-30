using System.Data;
using WPFToDoList.Model;

namespace WPFToDoList.Data
{
    /// <summary>
    /// 操作类型
    /// </summary>
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

        /// <summary>
        /// 查询任务
        /// </summary>
        /// <param name="optionType"></param>
        /// <returns></returns>
        public List<TaskModel> GetTaskData(OptionType optionType)
        {
            List<TaskModel> taskData = new List<TaskModel>();
            if (optionType == OptionType.offlineType)
            {
                return xmlConfig.GetDataFromXml("/Common/TaskData.xml");
            }
            else
            {
                string queryStr = "select * from dbo.tb_task;";
                DataTable dt = DbAccess.ExecuteDataTable(queryStr);
                foreach (DataRow dr in dt.Rows)
                {
                    TaskModel task = new TaskModel
                    {
                        TaskDescription = dr["TaskDescription"].ToString(),
                        TaskId = dr["TaskId"].ToString(),
                        TaskStatus = dr["TaskStatus"].ToString(),
                        TaskType = dr["TaskType"].ToString(),
                        CompletionDate = dr["CompletionDate"].ToString(),
                        EndDate = dr["EndDate"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        IsRecurring = dr["IsRecurring"].ToString(),
                        Tags = dr["Tags"].ToString(),
                    };
                    taskData.Add(task);
                }
            }
            return taskData;
        }

        /// <summary>
        /// 保存任务
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="taskModels"></param>
        /// <returns></returns>
        public int SaveTaskData(OptionType optionType, TaskModel taskModel)
        {
            string insertSql = string.Format(
                @"insert into dbo.tb_task(TaskDescription,TaskId,TaskStatus,TaskType,CompletionDate,EndDate,StartDate,IsRecurring,Tags)values
                 ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');", taskModel.TaskDescription, taskModel.TaskId, taskModel.TaskStatus,
                taskModel.TaskType, taskModel.CompletionDate, taskModel.EndDate, taskModel.StartDate, taskModel.IsRecurring, taskModel.Tags
                );
            int res = DbAccess.ExecuteDataNonQuery(insertSql);
            return res;
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public int UpdateTaskData(OptionType optionType, TaskModel taskModel)
        {
            string updateSql = string.Format(
                @"update dbo.tb_task set TaskDescription='{0}',CompletionDate='{1}',TaskStatus='{2}' where TaskId='{3}';",
                taskModel.TaskDescription, taskModel.CompletionDate, taskModel.TaskStatus, taskModel.TaskId);
            int res = DbAccess.ExecuteDataNonQuery(updateSql);
            return res;
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public int DeleteTaskData(OptionType optionType, TaskModel taskModel)
        {
            string updateSql = string.Format(
                @"delete from dbo.tb_task where TaskId='{0}';", taskModel.TaskId);
            int res = DbAccess.ExecuteDataNonQuery(updateSql);
            return res;
        }

    }
}
