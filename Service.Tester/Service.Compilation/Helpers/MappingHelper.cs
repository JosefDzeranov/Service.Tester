using System.Collections.Generic;
using Microsoft.CodeAnalysis.Emit;

namespace Service.Compilation.Helpers
{
    internal static class MappingHelper
    {
        internal static CompileResult ToCompileResult(this EmitResult emitResult)
        {
            var compileResult = new CompileResult { IsCompile = emitResult.Success, Errors = new List<Error>() };
            foreach (var diagnostic in emitResult.Diagnostics)
            {
                compileResult.Errors.Add(new Error { Message = diagnostic.GetMessage() });
            }
            return compileResult;
        }
    }
}