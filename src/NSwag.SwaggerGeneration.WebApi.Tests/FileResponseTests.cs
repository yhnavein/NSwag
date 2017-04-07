using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJsonSchema;
using NSwag.Annotations;

namespace NSwag.SwaggerGeneration.WebApi.Tests
{
    [TestClass]
    public class FileResponseTests
    {
        public class FileResponseController : ApiController
        {
            public IHttpActionResult GetFile(string fileName)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public async Task When_response_is_file_then_mime_type_is_bytes()
        {
            //// Arrange
            var generator = new WebApiToSwaggerGenerator(new WebApiAssemblyToSwaggerGeneratorSettings());

            //// Act
            var document = await generator.GenerateForControllerAsync<FileResponseController>();
            var json = document.ToJson();

            //// Assert
            var operation = document.Operations.First().Operation;

            //Assert.AreEqual("application/octet-stream", operation.ActualProduces.First());
            Assert.AreEqual(JsonObjectType.File, operation.Responses.First().Value.Schema.Type);
            Assert.IsTrue(operation.ActualProduces.Contains("application/octet-stream"));
        }

        public class TextResponseController : ApiController
        {
            [System.Web.Http.HttpGet]
            [System.Web.Http.Route("test")]
            [SwaggerResponse(HttpStatusCode.OK, Type = typeof(string), ContentTypes = new[] { "text/plain" })]
            [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(string))]
            public IHttpActionResult Foo()
            {
                return null;
            }
        }

        [TestMethod]
        public async Task When_response_has_content_type_other_than_json_then_it_is_file_and_content_type_is_added_to_operation_produces()
        {
            //// Arrange
            var generator = new WebApiToSwaggerGenerator(new WebApiAssemblyToSwaggerGeneratorSettings());

            //// Act
            var document = await generator.GenerateForControllerAsync<TextResponseController>();
            var json = document.ToJson();

            //// Assert
            var operation = document.Operations.First().Operation;

            //Assert.AreEqual("application/octet-stream", operation.ActualProduces.First());
            Assert.AreEqual(JsonObjectType.File, operation.Responses.First().Value.Schema.Type);
            Assert.IsTrue(operation.ActualProduces.Contains("text/plain"));
            Assert.IsTrue(operation.ActualProduces.Contains("application/json"));
        }
    }
}