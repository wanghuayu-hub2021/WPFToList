using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToDoList.Model
{
    /// <summary>
    /// 标签模型
    /// </summary>
    public class TagModel
    {
        /// <summary>
        /// Tag编号
        /// </summary>
        [Key]
        public required string TagId { get; set; } 
        /// <summary>
        /// Tag名称
        /// </summary>
        public string TagName { get; set; }
    }
}
