using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models
{
    public class CalculateModel
    {
        private LinkedList<Double> _numberList = new LinkedList<Double>();

        private bool _flagStandard = false;
        private bool _flagAverage = false;
        private double _cacheStandard = 0.0;
        private double _cacheAverage = 0.0;

        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 標準差
        /// </summary>
        public double Standard
        {
            get
            {
                if (!_flagStandard)
                {
                    var sigmaN = (from number in _numberList
                             select Math.Pow(number - Average, 2)).Sum();
                    _cacheStandard = Math.Sqrt( sigmaN / (_numberList.Count -1) );
                    _flagStandard = true;
                }

                return _cacheStandard;
            }
        }

        /// <summary>
        /// 平均
        /// </summary>
        public double Average
        {
            get
            {
                if (!_flagAverage)
                {
                    _cacheAverage = (from number in _numberList
                                    select number).Sum() / _numberList.Count;
                    _flagAverage = true;
                }

                return _cacheAverage;
            }
        }

        /// <summary>
        /// 加入數字
        /// </summary>
        /// <param name="numbers">數字列</param>
        public void Add(params double[] numbers)
        {
            foreach(var number in numbers)
                _numberList.AddLast(number);

            _flagStandard = false;
            _flagAverage = false;
        }
    }
}
