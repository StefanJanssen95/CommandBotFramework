using System;
using System.Collections.Generic;
using CommandBotFramework.Enums;
using Xunit;
namespace CommandBotFramework.Test.Attributes.Commands.CommandSignature
{
    public class CommandSignatureParse
    {
        [Fact]
        public void RunValidNoSignature()
        {
            var signature = new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute("");
            Assert.Empty(signature.Parameters);
        }
        
        [Fact]
        public void RunValidSingleNoTyped()
        {
            var paramName = "singleTest";
            var signature = new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute($"{{{paramName}}}");
            Assert.Single(signature.Parameters);
            Assert.Equal(paramName, signature.Parameters[0].Key);
            Assert.Equal(ParameterType.Unknown, signature.Parameters[0].Value);
        }

        [Fact]
        public void RunValidMultipleNoTyped()
        {
            var paramName1 = "param1";
            var paramName2 = "param2";
            var paramName3 = "param3";
            var signature = new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute($"{{{paramName1}}} {{{paramName2}}}{{{paramName3}}}");
            Assert.Equal(3, signature.Parameters.Count);
            Assert.Equal(paramName1, signature.Parameters[0].Key);
            Assert.Equal(paramName2, signature.Parameters[1].Key);
            Assert.Equal(paramName3, signature.Parameters[2].Key);
            Assert.Equal(ParameterType.Unknown, signature.Parameters[0].Value);
            Assert.Equal(ParameterType.Unknown, signature.Parameters[1].Value);
            Assert.Equal(ParameterType.Unknown, signature.Parameters[2].Value);
        }
        
        [Fact]
        public void RunValidSingleTyped()
        {
            var paramName = "singleTest";
            var param = $"{paramName}:string";
            var signature = new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute($"{{{param}}}");
            Assert.Single(signature.Parameters);
            Assert.Equal(paramName, signature.Parameters[0].Key);
            Assert.Equal(ParameterType.String, signature.Parameters[0].Value);
        }

        [Fact]
        public void RunValidMultipleTyped()
        {
            var paramName1 = "param1";
            var paramName2 = "param2";
            var paramName3 = "param3";
            var param1 = $"{paramName1}:bool";
            var param2 = $"{paramName2}:number";
            var param3 = $"{paramName3}:string";
            var signature = new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute($"{{{param1}}} {{{param2}}}{{{param3}}}");
            Assert.Equal(3, signature.Parameters.Count);
            Assert.Equal(paramName1, signature.Parameters[0].Key);
            Assert.Equal(paramName2, signature.Parameters[1].Key);
            Assert.Equal(paramName3, signature.Parameters[2].Key);
            Assert.Equal(ParameterType.Bool, signature.Parameters[0].Value);
            Assert.Equal(ParameterType.Number, signature.Parameters[1].Value);
            Assert.Equal(ParameterType.String, signature.Parameters[2].Value);
        }

        [Fact]
        public void RunValidMultiplePartialTyped()
        {
            var paramName1 = "param1";
            var paramName2 = "param2";
            var paramName3 = "param3";
            var param1 = $"{paramName1}:bool";
            var param2 = $"{paramName2}";
            var param3 = $"{paramName3}:string";
            
            var signature = new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute($"{{{param1}}} {{{param2}}}{{{param3}}}");
            Assert.Equal(3, signature.Parameters.Count);
            Assert.Equal(paramName1, signature.Parameters[0].Key);
            Assert.Equal(paramName2, signature.Parameters[1].Key);
            Assert.Equal(paramName3, signature.Parameters[2].Key);
            Assert.Equal(ParameterType.Bool, signature.Parameters[0].Value);
            Assert.Equal(ParameterType.Unknown, signature.Parameters[1].Value);
            Assert.Equal(ParameterType.String, signature.Parameters[2].Value);
        }
        
        [Fact]
        public void RunInvalidSingleUnknownTyped()
        {
            var paramName = "singleTest:int";
            Assert.Throws<FormatException>(() => new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute($"{{{paramName}}}"));
        }
        
        [Fact]
        public void RunInvalidSingle()
        {
            var paramName = "singleTest";
            Assert.Throws<FormatException>(() => new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute($"{paramName}"));
        }

        [Fact]
        public void RunInvalidSingleTyped()
        {
            var paramName = "singleTest string";
            Assert.Throws<FormatException>(() => new CommandBotFramework.Attributes.Commands.CommandSignatureAttribute($"{{{paramName}}}"));
        }
    }
}