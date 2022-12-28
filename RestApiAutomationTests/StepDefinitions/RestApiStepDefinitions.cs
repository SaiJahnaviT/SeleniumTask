using NUnit.Framework;
using RestApiAutomationBL.Utility;
using System.Xml;
using TechTalk.SpecFlow;

namespace RestApiAutomationTests.StepDefinitions
{
    [Binding]
    public sealed class RestApiStepDefinitions
    {
        [Given(@"I Create new post using id '([^']*)' title '([^']*)' and author '([^']*)'\.")]
        public void GivenICreateNewPostUsingIdTitleAndAuthor_(int id, string title, string author)
        {
            var response =BookUtils.Create(id, title, author);
            Assert.AreEqual(response.id, id);
            Assert.AreEqual(response.title, title);
            Assert.AreEqual(response.author, author);
        }


        [Given(@"I delete post using id '([^']*)'\.")]
        public void GivenIDeletePostUsingId_(int id)
        {
            var result= BookUtils.Delete(id);
            Console.WriteLine(result);
        }

        [Given(@"I Get posts using id '([^']*)'\.")]
        public void GivenIGetPostsUsingId_(int id)
        {
            var result=BookUtils.Get(id);
            Console.WriteLine(result.title+" : "+result.author);
        }

        [Given(@"I Change the post using id '([^']*)' title '([^']*)' and author '([^']*)'\.")]
        public void GivenIChangeThePostUsingIdTitleAndAuthor_(int id, string title, string author)
        {
            var response = BookUtils.Put(id, title, author);
            Assert.AreEqual(response.id, id);
            Assert.AreEqual(response.title, title);
            Assert.AreEqual(response.author, author);
        }

        [Given(@"I Change the post using id '([^']*)' title '([^']*)'\.")]
        public void GivenIChangeThePostUsingIdTitle_(int id, string title)
        {
            var Response = BookUtils.Patch(id, title);
            Console.WriteLine(Response.id);
            Console.WriteLine(Response.title);
            Console.WriteLine(Response.author);
        }



    }
}