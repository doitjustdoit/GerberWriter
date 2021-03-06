﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GerberWriter
{
    public class GerberWriter
    {
        List<IEntity> entities = new List<IEntity>();

        public void AddEntity(IEntity entity)
        {
            entities.Add(entity);
        }

        public string Validate()
        {
            string errors = "";
            foreach (var entity in entities)
            {
                errors += entity.Validate();
            }
            return errors;
        }

        public string Generate()
        {
            string file = "";

            file += "G04 Generated by GerberWriter *\n";
            file += "%FSLAX45Y45*%\n";
            file += "%MOMM*%\n";
            file += "%LPD*%\n";

            foreach(var entity in entities)
            {
                file += entity.Generate();
            }

            file += "M02*";
            return file;
        }
    }
}
