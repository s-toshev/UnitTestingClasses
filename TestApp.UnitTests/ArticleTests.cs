using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.UnitTests
{
    public class ArticleTests
    {
        private Article _article;

        [SetUp]
        public void SetUp()
        {
            this._article = new Article();
        }

        // Tests for AddArticles Method
        [Test]
        public void AddSingleArticle()
        {
            // Arrange
            string[] articles = { "Title1 Content1 Author1" };

            // Act
            Article result = this._article.AddArticles(articles);

            // Assert
            Assert.AreEqual(1, result.ArticleList.Count);
        }

        [Test]
        public void AddMultipleArticles()
        {
            // Arrange
            string[] articles = { "Title1 Content1 Author1", "Title2 Content2 Author2", "Title3 Content3 Author3" };

            // Act
            Article result = this._article.AddArticles(articles);

            // Assert
            Assert.AreEqual(3, result.ArticleList.Count);
        }

        [Test]
        public void AddArticlesWithEmptyData()
        {
            // Arrange
            string[] articles = { "   " };

            // Act
            Article result = this._article.AddArticles(articles);

            // Assert
            Assert.AreEqual(1, result.ArticleList.Count);
        }

        [Test]
        public void AddArticlesWithNullData()
        {
            // Arrange
            string[] articles = { null };

            // Act

            // Assert

            Assert.Throws<NullReferenceException>(()=> this._article.AddArticles(articles));
        }

        [Test]
        public void AddArticlesWithSpecialCharacters()
        {
            // Arrange
            string[] articles = { "!@#$ %^& *() <>? :; Title1 Content1 Author1" };

            // Act
            Article result = this._article.AddArticles(articles);

            // Assert
            Assert.AreEqual(1, result.ArticleList.Count);
        }

        // Tests for GetArticleList Method
        [Test]
        public void GetArticleListByTitleAscending()
        {
            // Arrange
            Article article = new Article();
            article.AddArticles(new string[] { "C ContentC AuthorC", "B ContentB AuthorB", "A ContentA AuthorA" });

            // Act
            string result = article.GetArticleList(article, "title");

            // Assert
            Assert.AreEqual("A - ContentA: AuthorA\nB - ContentB: AuthorB\nC - ContentC: AuthorC", result);
        }

        [Test]
        public void GetArticleListByContentAscending()
        {
            // Arrange
            Article article = new Article();
            article.AddArticles(new string[] { "TitleC ContentC AuthorC", "TitleB ContentC AuthorB", "TitleA ContentA AuthorA" });

            // Act
            string result = article.GetArticleList(article, "content");

            // Assert
            Assert.AreEqual("TitleA - ContentA: AuthorA\nTitleB - ContentB: AuthorB\nTitleC - ContentC: AuthorC", result);
        }

        [Test]
        public void GetArticleListByAuthorAscending()
        {
            // Arrange
            Article article = new Article();
            article.AddArticles(new string[] { "TitleC ContentC AuthorC", "TitleB ContentB AuthorB", "TitleA ContentA AuthorA" });

            // Act
            string result = article.GetArticleList(article, "author");

            // Assert
            Assert.AreEqual("TitleA ContentA AuthorA - ContentA: AuthorA\nTitleB ContentB AuthorB - ContentB: AuthorB\nTitleC ContentC AuthorC - ContentC: AuthorC", result);
        }


        [Test]
        public void GetArticleListByInvalidCriteria_ReturnsEmptyString()
        {
            // Arrange
            Article article = new Article();
            article.AddArticles(new string[] { "Title1 Content1 Author1", "Title2 Content2 Author2", "Title3 Content3 Author3" });

            // Act
            string result = article.GetArticleList(article, "invalid");

            // Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void GetArticleListWithEmptyArticleList_ReturnsEmptyString()
        {
            // Arrange
            Article article = new Article();

            // Act
            string result = article.GetArticleList(article, "title");

            // Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void GetArticleListWithNullArticleList_ReturnsEmptyString()
        {
            // Arrange
            Article article = new Article();
            article.ArticleList = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(()=> article.GetArticleList(article,"title"));
        }

        [Test]
        public void GetArticleListWithEmptyCriteria_ReturnsEmptyString()
        {
            // Arrange
            Article article = new Article();
            article.AddArticles(new string[] { "Title1 Content1 Author1", "Title2 Content2 Author2", "Title3 Content3 Author3" });

            // Act
            string result = article.GetArticleList(article, "");

            // Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void GetArticleListWithNullCriteria_ReturnsEmptyString()
        {
            // Arrange
            Article article = new Article();
            article.AddArticles(new string[] { "Title1 Content1 Author1", "Title2 Content2 Author2", "Title3 Content3 Author3" });

            // Act
            string result = article.GetArticleList(article, null);

            // Assert
            Assert.AreEqual("", result);
        }

    }


}
