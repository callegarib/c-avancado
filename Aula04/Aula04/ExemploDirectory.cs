﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula04
{
    public class ExemploDirectory
    {
        public string[] TrazerTodosOsArquivos(string caminhoDaPasta)
        {
            return Directory.GetDirectories(caminhoDaPasta);
        }
    }
}