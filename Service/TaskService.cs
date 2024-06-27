using WPFToDoList.Data;
using WPFToDoList.Model;

namespace WPFToDoList.Service
{
    public class TaskService
    {
        public TaskDatatAccess taskDataAccess = new TaskDatatAccess();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="optionType"></param>
        /// <returns></returns>
        public List<TaskModel> GetTaskData(OptionType optionType)
        {
            return taskDataAccess.GetTaskData(optionType);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="taskModels"></param>
        /// <returns></returns>
        public int SaveTaskData(OptionType optionType, TaskModel taskModels)
        {
            return taskDataAccess.SaveTaskData(optionType, taskModels);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public int UpdateTaskData(OptionType optionType, TaskModel taskModel)
        {
            return taskDataAccess.UpdateTaskData(optionType, taskModel);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="optionType"></param>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        public int DeleteTaskData(OptionType optionType, TaskModel taskModel)
        {
            return taskDataAccess.DeleteTaskData(optionType, taskModel);
        }
    }
}
