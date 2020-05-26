using System;
using System.Collections.Generic;
using System.Text;
using jory.abp.Application;

namespace jory.abp.HelloWorld.Impl
{
    public class HelloWorldService : JoryAbpApplicationServiceBase, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
