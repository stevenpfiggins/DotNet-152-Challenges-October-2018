using System;
using System.Collections.Generic;
using Challenge_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_2_Tests
{
    [TestClass]
    public class Challenge_2_Tests
    {
        ClaimRepository _claimRepo = new ClaimRepository();
        Claim claim;
        Queue<Claim> claims;
        [TestMethod]
        public void ClaimRepository_AddClaimToQueue_ShouldIncreaseCountByOne()
        {
            //Arrange
            claim = new Claim(1, "house", "fire", 500m, new DateTime(2018, 5, 25), new DateTime(2018, 5, 30), true);
            claims = _claimRepo.SeeClaimQueue();
            _claimRepo.AddClaimToQueue(claim);

            //Act
            var actual = claims.Count;
            var expected = 1;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
