﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDB_using_EF
{
    internal interface ICrudOpration
    {
        void Add();
        void Update(int Id);
        void Delete(int Id);
        void Read();
    }
}
