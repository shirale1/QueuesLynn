using Queues.Models;
using System;

//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class QueueHelper
    {
        /// <summary>
        /// פעולת ספירת כמות איברים בתור 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <returns></returns>
        public static int Count<T>(Queue<T> q)
        {
            int counter = 0;
            //ניצור עותק נוסף של התור
            Queue<T> temp = Copy(q);
            //נרוקן את העותק
            while (!temp.IsEmpty())
            {
                counter++;
                temp.Remove();
            }
            //נחזיר את הכמות
            return counter;
        }
        /// <summary>
        /// פעולה הסופרת כמות איברים בתור ללא שימוש בפעולת עזר
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q"></param>
        /// <returns></returns>

        public static int Count2<T>(Queue<T> q)
        {
            int counter = 0;
            Queue<T> temp = new Queue<T>();
            //נעתיק את הערכים לתור חדש
            while (!q.IsEmpty())
            {
                temp.Insert(q.Remove());
                counter++;
            }
            //נחזיר את הערכים חזרה לתור המקורי
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            //נחזיר את הכמות
            return counter;
        }
        /// <summary>
        /// פעולה היוצרת עותק של התור
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Queue<T> Copy<T>(Queue<T> original)
        {
            Queue<T> copy = new Queue<T>();
            Queue<T> temp = new Queue<T>();
            while (!original.IsEmpty())
            {
                temp.Insert(original.Remove());

            }
            while (!temp.IsEmpty())
            {
                copy.Insert(temp.Head());
                original.Insert(temp.Remove());
            }
            return copy;

        }
    }
}
