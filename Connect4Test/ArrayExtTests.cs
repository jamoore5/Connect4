using System;
using Connect4.Extension;
using Xunit;

namespace Connect4Test
{
    public class ArrayExtTests
    {
        [Fact]
        public void GetRow_FirstRow()
        {
            var array = new [,] {{1,2,3,4}, {5,6,7,8}};
            
            var actual = array.GetRow(0);
            
            Assert.Equal(new []{1,2,3,4}, actual);
        }
        
        [Fact]
        public void GetRow_SecondRow()
        {
            var array = new [,] {{1,2,3,4}, {5,6,7,8}};
            
            var actual = array.GetRow(1);
            
            Assert.Equal(new []{5,6,7,8}, actual);
        }
        
        [Fact]
        public void GetRow_OutOfBounds()
        {
            var array = new [,] {{1,2,3,4}, {5,6,7,8}};
            
            Assert.Throws<IndexOutOfRangeException>(() => array.GetRow(2));
            
        }
        
        [Fact]
        public void GetColumn_First()
        {
            var array = new[,] {{1, 5}, {2, 6}, {3, 7}, {4, 8}};

            var actual = array.GetColumn(0);
            
            Assert.Equal(new []{1,2,3,4}, actual);
        }
        
        [Fact]
        public void GetColumn_Second()
        {
            var array = new[,] {{1, 5}, {2, 6}, {3, 7}, {4, 8}};
            
            var actual = array.GetColumn(1);
            
            Assert.Equal(new []{5,6,7,8}, actual);
        }
        
        [Fact]
        public void GetColumn_OutOfBounds()
        {
            var array = new[,] {{1, 5}, {2, 6}, {3, 7}, {4, 8}};
            
            Assert.Throws<IndexOutOfRangeException>(() => array.GetColumn(2));
            
        }
    }
}