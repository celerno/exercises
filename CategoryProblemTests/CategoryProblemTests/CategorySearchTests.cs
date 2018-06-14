using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CategoryFinder;
using System.Linq;

namespace CategoryProblemTests
{
    [TestClass]
    public class UnitTest
    {
        /*
         * Question: 
            Sample Dataset: 
            CategoryId  ParentCategoryId    Name        Keywords 
            100         -1                  Business    Money 
            200         -1                  Tutoring    Teaching 
            101         100                 Accounting  Taxes 
            102         100                 Taxation  
            201         200                 Computer  
            103         101                 Corporate Tax  
            202         201                 Operating System  
            109         101                 Small business Tax  
 
            Write a working program which should do the following: 
            a. Given a category id return category name, parentCategoryId and key-word. Ensure that if 
            key-word is not present for the category, then the data from its parent should be 
            returned. 
            Sample Input/Output: 
            i. Input: 201; Output: ParentCategoryID=200, Name=Computer, 
            Keywords=Teaching 
            ii. Input: 202; Output: ParentCategoryID=201, Name=Operating System, 
            Keywords=Teaching 
            b. Given category level as parameter (say N) return the names of the categories which are 
            of N’th level in the hierarchy (categories with parentId -1 are at 1st level). 
            Sample Input/Output: 
            i. Input: 2; Output: 101, 102, 201 
            ii. Input: 3; Output: 103, 109, 202
         */
        List<Category> data;
        Search search;
        [TestInitialize]
         public void TestSetup()
        {
            data = new List<Category>();
            data.Add(new Category { CategoryId = 100, ParentCategoryId = -1, Name = "Business", Keywords = "Money" });
            data.Add(new Category { CategoryId = 200, ParentCategoryId = -1, Name = "Tutoring", Keywords = "Teaching" });
            data.Add(new Category { CategoryId = 101, ParentCategoryId = 100, Name = "Accounting", Keywords = "Taxes" });
            data.Add(new Category { CategoryId = 102, ParentCategoryId = 100, Name = "Taxation", Keywords = "" });
            data.Add(new Category { CategoryId = 201, ParentCategoryId = 200, Name = "Computer", Keywords = "" });
            data.Add(new Category { CategoryId = 103, ParentCategoryId = 101, Name = "Corporate Tax", Keywords = "" });
            data.Add(new Category { CategoryId = 202, ParentCategoryId = 201, Name = "Operating System", Keywords = "" });
            data.Add(new Category { CategoryId = 109, ParentCategoryId = 101, Name = "Small business Tax", Keywords = "" });

            search = new Search(data);
        }

        [TestMethod]
        public void Given_CategoryId_When_KeywordIsEmpty_Then_ParentKeyword()
        {
            var actual = search.GetCategoryById(201);
            Assert.AreEqual(200, actual.ParentCategoryId);
            Assert.AreEqual("Computer", actual.Name);
            Assert.AreEqual("Teaching", actual.Keywords);

            actual = search.GetCategoryById(202);
            Assert.AreEqual(201, actual.ParentCategoryId);
            Assert.AreEqual("Operating System", actual.Name);
            Assert.AreEqual("Teaching", actual.Keywords);

            //extra tests

            actual = search.GetCategoryById(int.MaxValue);
            Assert.IsNull(actual);
        }
        [TestMethod]
        public void Given_CategorySet_When_LevelN_Then_Categories_Of_Nth_Level()
        {
            var actual = search.GetByLevel(2);
            Assert.IsTrue(actual.Contains("Accounting"));
            Assert.IsTrue(actual.Contains("Taxation"));
            Assert.IsTrue(actual.Contains( "Computer"));

            actual = search.GetByLevel(3);
            Assert.IsTrue(actual.Contains( "Corporate Tax"));
            Assert.IsTrue(actual.Contains( "Small business Tax"));
            Assert.IsTrue(actual.Contains( "Operating System"));

            //extra tests
            actual = search.GetByLevel(1);
            Assert.IsTrue(actual.Contains("Business"));
            Assert.IsTrue(actual.Contains("Tutoring"));

            actual = search.GetByLevel(int.MaxValue);
            Assert.IsTrue(actual.Count() == 0);

            actual = search.GetByLevel(0);
            Assert.IsTrue(actual.Count() == 0);


        }
    }
}
