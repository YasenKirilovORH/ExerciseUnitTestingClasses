using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace TestApp.UnitTests
{
    public class ArticleTests
    {
        private Article article;

        [SetUp]
        public void SetUp()
        {
            article = new Article();
        }

        [Test]
public void Test_AddArticles_ReturnsArticleWithCorrectData()
{
    // Arrange
    string[] articles = 
    { 
        "Article Content Author",
        "Article1 Content1 Author1",
        "Article2 Content2 Author2"
    };

    // Act
    Article actual = article.AddArticles(articles);

    // Assert
    Assert.That(actual.ArticleList, Has.Count.EqualTo(3));
            Assert.That(actual.ArticleList[0].Title, Is.EqualTo("Article"));
            Assert.That(actual.ArticleList[1].Content, Is.EqualTo("Content1"));
            Assert.That(actual.ArticleList[2].Author, Is.EqualTo("Author2"));
}

        [Test]
        public void Test_GetArticleList_SortsArticlesByTitle()
        {
            // Arrange
            string[] articles =
            {
        "NewArticle Content1 Author1",
        "OldArticle Content2 Author2",
        "Article Content Author"
            };
            string expected = $"Article - Content: Author{Environment.NewLine}" +
                              $"NewArticle - Content1: Author1{Environment.NewLine}" +
                              $"OldArticle - Content2: Author2";

            // Act
            Article result = article.AddArticles(articles);
            string actual = article.GetArticleList(result, "title");

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
        {
            // Arrange
            string[] articles =
            {
        "NewArticle Content1 Author1",
        "OldArticle Content2 Author2",
        "Article Content Author"
            };

            // Act
            Article result = article.AddArticles(articles);
            string actual = article.GetArticleList(result, "wrongCriteria");

            // Assert
            Assert.That(actual, Is.EqualTo(string.Empty));
        }
    }
}