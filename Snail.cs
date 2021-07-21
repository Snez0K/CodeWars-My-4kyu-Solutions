/*Snail Sort
Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

array = [[1,2,3],
         [4,5,6],
         [7,8,9]]
snail(array) #=> [1,2,3,6,9,8,7,4,5]
For better understanding, please follow the numbers of the next array consecutively:
*/

//Useless "For" solution
public class SnailSolution
{
   public static int[] Snail(int[][] array)
   {
       int[] result = new int[array.Length*array.Length];
     if(array.Length == 1) return array[0];
        
       int temp = 0;
       int left=0, top=array.Length-1, right=0, bottom=array.Length-1;
       
       for(int i = 0; i < array.Length / 2; i++){
           for(int a=left; a<=top; a++){
               result[temp++] = array[right][a];
           }
            right++;
           for(int b = right; b <= bottom; b++){
               result[temp++] = array[b][top];
           }
            top--;
           for(int c = top; c >= left; c--){
               result[temp++] = array[bottom][c];
           }
            bottom--;
           for(int d = bottom; d >= right; d--){
               result[temp++] = array[d][left];
           }
            left++;
       }
       if(array.Length % 2 != 0){
           result[temp]=array[left][right];
       }
       
       return result;
   }
}

//Real "LinQ" Boys Solution ♛ 
using System.Collections.Generic;
using System.Linq;
public class SnailSolution
{
   public static IEnumerable<int> Snail(int[][] a, int r = 0)
   {
      int n = a[0].Length - 1 - 2 * r;
      if (n < 0) return new int[0];
      if (n == 0) return new []{a[r][r]};
      
      var sides = new []{
        a[r],                             // Top
        a.Select(x => x[r+n]),            // Right
        a[r+n].Reverse(),                 // Bottom
        a.Select(x => x[r]).Reverse()     // Left
      }
      .SelectMany(x => x.Skip(r).Take(n));
 
      return (n == 1) ? sides : sides.Concat(Snail(a, r+1));
   }
}
