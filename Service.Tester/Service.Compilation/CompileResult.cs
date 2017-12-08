using System.Collections.Generic;

namespace Service.Compilation
{

    public sealed class CompileResult
    {
        public bool IsCompile { get; set; }

        public List<Error> Errors { get; set; }

        public string PathToAssembly { get; set; }
    }

}