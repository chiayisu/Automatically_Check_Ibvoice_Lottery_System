using System;
using System.Collections.Generic;
using System.Text;

namespace CY.Core.Models
{
    public class UserResponse
    {
        private List<string> _winningNumber;
        private List<string> _winningName;
        private List<string> _others;
        public UserResponse()
        {
            _winningNumber = new List<string>();
            _winningName = new List<string>();
            _others = new List<string>();
             
        }
        public List<string> WonNumbers
        {
            get
            {
                return _winningNumber;
            }
            set
            {
                _winningNumber = value;
            }
        }

        public List<string> WonName
        {
            get
            {
                return _winningName;
            }
            set
            {
                _winningName = value;
            }
        }

        public List<string> LosedNumber
        {
            get
            {
                return _others;
            }
            set
            {
                _others = value;
            }
        }
    }
}
