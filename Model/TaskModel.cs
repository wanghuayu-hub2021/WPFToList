using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToDoList.Model
{
    public class TaskModel
    {
        /// <summary>
        /// 任务描述
        /// </summary>
        public  string TaskDescription { get; set; }

        /// <summary>
        /// 任务编号
        /// </summary>
        public  string TaskId { get; set; }

        /// <summary>
        /// 子任务，这里假设子任务是一个字符串，可能包含子任务的列表或描述
        /// </summary>
        //public List<SubTaskModel> SubTasks { get; set; }

        /// <summary>
        /// 任务完成状态，0 未开始 1 进行中 2 完成
        /// </summary>
        public string TaskStatus { get; set; }

        /// <summary>
        /// 任务类型，例如 在线任务 0 离线任务 1 
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// 完成日期
        /// </summary>
        public string CompletionDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 是否是重复任务，0 非重复 1 重复
        /// </summary>
        public string IsRecurring { get; set; }

        /// <summary>
        /// 标签分类
        /// </summary>
        public string Tags { get; set; }

        public override string ToString()
        {
            return $"Task ID: {TaskId}, Description: {TaskDescription}, Status: {TaskStatus}, Type: {TaskType}, Start Date: {StartDate}, Completion Date: {CompletionDate}, Recurring: {IsRecurring}, Tags: {Tags}";
        }
    }

    public class SubTaskModel
    {
        /// <summary>
        /// 子任务描述
        /// </summary>
        public  string SubTaskDescription { get; set; }

        /// <summary>
        /// 子任务编号
        /// </summary>
        public  string SubTaskId { get; set; }

        /// <summary>
        /// 父任务编号
        /// </summary>
        public string TaskId { get; set; }

        /// <summary>
        /// 任务完成状态，0 未开始 1 进行中 2 完成
        /// </summary>
        public string SubTaskStatus { get; set; }

        /// <summary>
        /// 完成日期
        /// </summary>
        public string CompletionDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 是否是重复任务，0 非重复 1 重复
        /// </summary>
        public string IsRecurring { get; set; }
    }
}
