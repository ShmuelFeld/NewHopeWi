using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MazeLib;
using ModelCL;

namespace WebApi.Models
{
    public class WebModel
    {
        private IModel model;
        public WebModel()
        {
            this.model = new Model();
        }

        public string GenerateMaze(string name, int rows, int cols)
        {
            return model.GenerateMaze(name, rows, cols).ToJSON();            
        }
    }
}