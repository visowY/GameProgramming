using System;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;

namespace D_DesignPattern
{
    public class TypeCreator
    {

        public void Do()
        {
            // 1.构建程序集
            var asmName = new AssemblyName("Test");
            var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
            
            
            // 2.创建模块
            var mdlBldr = asmBuilder.DefineDynamicModule("Elvinle", "Elvinle.ext");
            
            
            // 3.定义类
            var typeBldr = mdlBldr.DefineType("Hello", TypeAttributes.Public);
            
            // 4.定义类成员（方法属性等）
            var methodBldr = typeBldr.DefineMethod("SayHello", MethodAttributes.Public | MethodAttributes.Static,
                null, null);
            
            // 5.构建方法体
            var il = methodBldr.GetILGenerator();
            il.Emit(OpCodes.Ldstr, "Hello, hello world");
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[]{typeof(string)}));
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("ReadLine"));
            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ret);

            var t = typeBldr.CreateType();
            asmBuilder.SetEntryPoint(t.GetMethod("SayHello"));
            asmBuilder.Save("Elvinle.ext");
        }

     
      
    }
}