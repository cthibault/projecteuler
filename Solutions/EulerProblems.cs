using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Oyster.Math;
using ProjectEuler.Solutions.Algorithms;
using System.Globalization;

namespace ProjectEuler.Solutions
{
    public class EulerProblems
    {
        private List<Problem> _problems;
        private Dictionary<int, Problem> _problemsById;
        private Stopwatch _watch;

        public EulerProblems()
        {
            _problems = new List<Problem>
            {
                new Problem(1, "What is the sum of all the multiples of 3 or 5 below 1000?")
                {
                    new Approach
                    {
                        Title = "Bruteforce", 
                        Algorithm = new Algorithm<long>(new Func<long>(problem1_1))
                    }
                },
                new Problem(2, "What is the sum of all the even-valued terms in the Fibonacci Sequence which do not exceed 4,000,000?")
                {
                    new Approach
                    {
                        Title = "Bruteforce", 
                        Algorithm = new Algorithm<long>(new Func<long>(problem2_1))
                    }
                },
                new Problem(3, "What is the largest prime factor of the number 600851475143?")
                {
                    new Approach 
                    { 
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<long>(new Func<long>(problem3_1))
                    }
                },
                new Problem(4, "What is the largest palindrome made from the product of two 3-digit numbers?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<int>(new Func<int>(problem4_1))
                    }
                },
                new Problem(5, "What is the smallest number that is evenly divisible by all of the numbers from 1 to 20?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        WarmupRounds = 1,
                        BenchmarkRounds = 1,
                        Algorithm = new Algorithm<long>(new Func<long>(problem5_1))
                    }
                },
                new Problem(6, "What is the difference between the sum of the squares and the square of the sums for the firt 100 natural numbers?")
                {
                    new Approach
                    {
                        Title = "Bruteforce 1",
                        Algorithm = new Algorithm<double>(new Func<double>(problem6_1))
                    },
                    new Approach
                    {
                        Title = "Bruteforce 2",
                        Algorithm = new Algorithm<double>(new Func<double>(problem6_2))
                    }
                },
                new Problem(7, "What is the 10,001st prime number?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<long>(new Func<long>(problem7_1))
                    }
                },
                new Problem(8, "What is the greatest product of five consecutive digits in the 1000 digit number?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<double>(new Func<double>(problem8_1))
                    }
                },
                new Problem(9, "Find the product of abc where: a<b<c, a^2 + b^2 = c^2, and a + b + c = 1000.")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<string>(new Func<string>(problem9_1))
                    }
                },
                new Problem(10, "What is the sum of all the primes below two million?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<long>(new Func<long>(problem10_1))
                    },
                    new Approach
                    {
                        Title = "Eratosthenes Sieve 1",
                        Algorithm = new Algorithm<double>(new Func<double>(problem10_2))
                    }
                },
                new Problem(11, "What is the greatest product of four adjacent numbers in any direction in the 20x20 grid?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<double>(new Func<double>(problem11_1))
                    }
                },
                new Problem(12, "What is the first triangle number to have over 500 divisors?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<double>(new Func<double>(problem12_1))
                    }
                },
                new Problem(13, "What are the first 10 digits of the sum of the 100 50-digit numbers?")
                {
                    new Approach
                    {
                        Title = "Bruteforce (String Manipulation)",
                        Algorithm = new Algorithm<long>(new Func<long>(problem13_1))
                    }
                },
                new Problem(14, string.Format("{1}{0}{2}{0}{0}{3}", Environment.NewLine, "n -> n/2 (n is even)", "n -> 3n + 1 (n is odd)", "Which starting number under 1,000,000 produces the longest chain?"))
                {
                    new Approach
                    {
                        //TODO: Add Title
                        Algorithm = new Algorithm<string>(new Func<string>(problem14_1))
                    }
                },
                new Problem(15, "How many routes (w/o backtracking) are there from the top left corner to the bottom right corner of a 20x20 grid?")
                {
                    new Approach
                    {
                        Title = "Pascal's Triangle",
                        Algorithm = new Algorithm<double>(new Func<double>(problem15_1))
                    }
                },
                new Problem(16, "What is the sum of the digits of the number 2^1000?")
                {
                    new Approach
                    {
                        //TODO: Add Title
                        Algorithm = new Algorithm<IntX>(new Func<IntX>(problem16_1))
                    }
                },
                new Problem(17, "How many letters would be used to write out the numbers 1 through 1000?")
                {
                    new Approach
                    {
                        Title = "Bruteforce",
                        Algorithm = new Algorithm<int>(new Func<int>(problem17_1))
                    }
                },
                new Problem(20, "Find the sum of the digits of the number 100!")
                {
                    new Approach
                    {
                        Algorithm = new Algorithm<IntX>(new Func<IntX>(problem20_1))
                    }
                }
            };

            _problemsById = _problems.ToDictionary(p => p.ID);
            _watch = new Stopwatch();
        }

        public void RunProblem(int id)
        {
            Problem problem;
            if (!_problemsById.TryGetValue(id, out problem))
            {
                Console.WriteLine("Problem {0} is not available.", id);
                return;
            }

            problem.Run(_watch);
        }

        #region Problems

        private long problem1_1()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
                if (i.IsMultiple(3) || i.IsMultiple(5))
                    sum += i;
            return sum;
        }
        
        private long problem2_1()
        {
            long sum = 0;
            IEnumerable<long> fibSeq = Sequences.EnumerateFibonacci(4000000);
            
            foreach (long term in fibSeq)
                if (term % 2 == 0)
                    sum += term;
            return sum;
        }
        
        private long problem3_1()
        {
            return Convert.ToInt64(600851475143d.getPrimeFactors().Max());
        }
        
        private int problem4_1() 
        {
            int max = 0;
            int term = 0;

            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    term = i * j;
                    if (term.IsPalindrom())
                    {
                        if (term > max)
                            max = term;
                    }
                }
            }
            return max;
        }
        
        private long problem5_1()       //TODO: I need a better solution for this problem!
        {
            long answer = -1;
            for (long i = 2520; i < 400000000; i++)
            {
                for (long j = 2; j < 21; j++)
                {
                    if (i % j != 0)
                        break;

                    if (j == 20)
                        answer = i;
                }

                if (answer > 0)
                    break;
            }
            return answer;
        }
        
        private double problem6_1()
        {
            int numberOfTerms = 100;
            return numberOfTerms.SquareOfSums() - numberOfTerms.SumOfSquares();
        }
        private double problem6_2()
        {
            double sum_squares = 0;
            double square_sums = 0;
            int numberOfTerms = 100;
            for (int i = 1; i <= numberOfTerms; i++)
            {
                sum_squares += i * i;
                square_sums += i;
            }
            square_sums *= square_sums;

            return square_sums - sum_squares;
        }
        
        private long problem7_1()
        {
            int count = 0;
            long number = 1;
            int desiredTerm = 10001;
            while (count < desiredTerm)
            {
                number++;
                if (number.IsPrime())
                    count++;
            }
            return number;
        }
        
        private double problem8_1()
        {
            string number = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            double product = 0;
            double temp = 1;
            int count = -1;

            int[] consecutiveValues = new int[5];
            consecutiveValues[0] = Convert.ToInt32(number[0].ToString());
            consecutiveValues[1] = Convert.ToInt32(number[1].ToString());
            consecutiveValues[2] = Convert.ToInt32(number[2].ToString());
            consecutiveValues[3] = Convert.ToInt32(number[3].ToString());
            consecutiveValues[4] = Convert.ToInt32(number[4].ToString());

            for (int i = 4; i < number.Length; i++)
            {
                if (count >= 0)
                    consecutiveValues[count % 5] = Convert.ToInt32(number[i].ToString());

                foreach (int num in consecutiveValues)
                    temp *= num;
                if (temp > product)
                    product = temp;

                count++;
                temp = 1;
            }

            return product;
        }

        private string problem9_1()
        {
            List<Triangle> possibleTriangles = new List<Triangle>();
            Triangle answer = new Triangle();
            for (int a = 1; a < 995; a++)
            {
                for (int b = a + 1; b < 996; b++)
                {
                    for (int c = b + 1; c < 997; c++)
                    {
                        if (a + b + c == 1000)
                            possibleTriangles.Add(new Triangle(a, b, c));
                    }
                }
            }

            foreach (Triangle triange in possibleTriangles)
            {
                if (triange.IsPythagoreanTriplet())
                {
                    answer = triange;
                    break;
                }
            }

            return string.Format("{0}a = {2}{1}{0}b = {3}{0}c = {4}{0}{1}a*b*c = {5}",
                " ", Environment.NewLine, answer.SideA, answer.SideB, answer.SideC, answer.ProductOfSides());
        }
        
        private long problem10_1()
        {
            long sum = 2;
            long maxTerm = 2000000;
            for (long i = 3; i < maxTerm; i += 2)
            {
                if (i.IsPrime())
                    sum += i;
            }
            return sum;
        }
        private double problem10_2()        //TODO: Find a better way to implement Eratosthenes Sieve
        {
            long maxTerm = 2000000;
            List<bool> list = new List<bool>();
            for (int i = 0; i < maxTerm; i++)
                list.Add(true);
            list[0] = false;
            list[1] = false;
            list = _eratosthenesSieve(list, 2);

            double sum = 0;
            for (int i = 0; i < maxTerm; i++)
            {
                if (list[i])
                    sum += i;
            }
            return sum;
        }
        private static List<bool> _eratosthenesSieve(List<bool> list, int currentMultiple)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                if (list[i])
                {
                    if (currentMultiple > Math.Sqrt(i))
                        return list;
                    break;
                }
            }

            for (int i = currentMultiple * 2; i < list.Count; i += currentMultiple)
                list[i] = false;

            int nextMultiple = 0;
            for (int i = currentMultiple + 1; i < list.Count; i++)
            {
                if (list[i])
                {
                    nextMultiple = i;
                    break;
                }
            }

            return _eratosthenesSieve(list, nextMultiple);
        }
        
        private double problem11_1()
        {
            double[,] table = new double[,] { { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 }, { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 }, { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 }, { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 }, { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 }, { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 }, { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 }, { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 }, { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 }, { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 }, { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 }, { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 }, { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 }, { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 }, { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 }, { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 }, { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 }, { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 }, { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 }, { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 } };
            int consecutiveTerms = 4;
            double product = 0;
            double temp = 0;

            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    //Console.WriteLine("[{0},{1}] ", x, y);
                    foreach (Directions direction in Enum.GetValues(typeof(Directions)))
                    {
                        //Console.Write("{0} -> ", direction.ToString().ToUpper());
                        switch (direction)
                        {
                            case Directions.North:
                                if (x - (consecutiveTerms - 1) >= 0)
                                    temp = productNorth(table, x, y, consecutiveTerms);
                                break;
                            case Directions.NorthEast:
                                if ((x - (consecutiveTerms - 1) >= 0) &&
                                   (y + (consecutiveTerms - 1) < 20))
                                    temp = productNorthEast(table, x, y, consecutiveTerms);
                                break;
                            case Directions.East:
                                if (y + (consecutiveTerms - 1) < 20)
                                    temp = productEast(table, x, y, consecutiveTerms);
                                break;
                            case Directions.SouthEast:
                                if ((x + (consecutiveTerms - 1) < 20) &&
                                    (y + (consecutiveTerms - 1) < 20))
                                    temp = productSouthEast(table, x, y, consecutiveTerms);
                                break;
                            case Directions.South:
                                if (x + (consecutiveTerms - 1) < 20)
                                    temp = productSouth(table, x, y, consecutiveTerms);
                                break;
                            case Directions.SouthWest:
                                if ((x + (consecutiveTerms - 1) < 20) &&
                                    (y - (consecutiveTerms - 1) >= 0))
                                    temp = productSouthWest(table, x, y, consecutiveTerms);
                                break;
                            case Directions.West:
                                if (y - (consecutiveTerms - 1) >= 0)
                                    temp = productWest(table, x, y, consecutiveTerms);
                                break;
                            case Directions.NorthWest:
                                if ((x - (consecutiveTerms - 1) >= 0) &&
                                    (y - (consecutiveTerms - 1) >= 0))
                                    temp = productNorthWest(table, x, y, consecutiveTerms);
                                break;
                            default:
                                break;
                        }

                        //if (temp != 0) 
                        //    Console.WriteLine(" = {0}", temp); 
                        //else
                        //    Console.WriteLine("INVALID");

                        if (product < temp) product = temp;
                        temp = 0;
                    }
                }
            }
            return product;
        }
        private void printGrid(double[,] table)
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (table[x, y] < 10)
                        Console.Write("0");
                    Console.Write(table[x, y].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
        private double productNorth(double[,] table, int x, int y, int consecutiveTerms)
        {
            //Console.Write(table[x, y]);
            if (consecutiveTerms == 1)
                return table[x, y];

            //Console.Write(" * ");
            return table[x, y] * productNorth(table, x - 1, y, consecutiveTerms - 1);
        }
        private double productNorthEast(double[,] table, int x, int y, int consecutiveTerms)
        {
            //Console.Write(table[x, y]);
            if (consecutiveTerms == 1)
                return table[x, y];

            //Console.Write(" * ");
            return table[x, y] * productNorthEast(table, x - 1, y + 1, consecutiveTerms - 1);
        }
        private double productEast(double[,] table, int x, int y, int consecutiveTerms)
        {
            //Console.Write(table[x, y]);
            if (consecutiveTerms == 1)
                return table[x, y];

            //Console.Write(" * ");
            return table[x, y] * productEast(table, x, y + 1, consecutiveTerms - 1);
        }
        private double productSouthEast(double[,] table, int x, int y, int consecutiveTerms)
        {
            //Console.Write(table[x, y]);
            if (consecutiveTerms == 1)
                return table[x, y];

            //Console.Write(" * ");
            return table[x, y] * productSouthEast(table, x + 1, y + 1, consecutiveTerms - 1);
        }
        private double productSouth(double[,] table, int x, int y, int consecutiveTerms)
        {
            //Console.Write(table[x, y]);
            if (consecutiveTerms == 1)
                return table[x, y];

            //Console.Write(" * ");
            return table[x, y] * productSouth(table, x + 1, y, consecutiveTerms - 1);
        }
        private double productSouthWest(double[,] table, int x, int y, int consecutiveTerms)
        {
            //Console.Write(table[x, y]);
            if (consecutiveTerms == 1)
                return table[x, y];

            //Console.Write(" * ");
            return table[x, y] * productSouthWest(table, x + 1, y - 1, consecutiveTerms - 1);
        }
        private double productWest(double[,] table, int x, int y, int consecutiveTerms)
        {
            //Console.Write(table[x, y]);
            if (consecutiveTerms == 1)
                return table[x, y];

            //Console.Write(" * ");
            return table[x, y] * productWest(table, x, y - 1, consecutiveTerms - 1);
        }
        private double productNorthWest(double[,] table, int x, int y, int consecutiveTerms)
        {
            //Console.Write(table[x, y]);
            if (consecutiveTerms == 1)
                return table[x, y];

            //Console.Write(" * ");
            return table[x, y] * productNorthWest(table, x - 1, y - 1, consecutiveTerms - 1);
        }

        private double problem12_1()
        {
            double term = 0;
            double triangleNumber = 0;

            do
            {
                term++;
                triangleNumber = term.TriangleNumber();
            } while (triangleNumber.NumberOfDivisors() < 500);

            return triangleNumber;
        }

        private long problem13_1()
        {
            long sum = 0;
            int digitLenth = 50;
            string number = "37107287533902102798797998220837590246510135740250463769376774900097126481248969700780504170182605387432498619952474105947423330951305812372661730962991942213363574161572522430563301811072406154908250230675882075393461711719803104210475137780632466768926167069662363382013637841838368417873436172675728112879812849979408065481931592621691275889832738442742289174325203219235894228767964876702721893184745144573600130643909116721685684458871160315327670386486105843025439939619828917593665686757934951621764571418565606295021572231965867550793241933316490635246274190492910143244581382266334794475817892575867718337217661963751590579239728245598838407582035653253593990084026335689488301894586282278288018119938482628201427819413994056758715117009439035398664372827112653829987240784473053190104293586865155060062958648615320752733719591914205172558297169388870771546649911559348760353292171497005693854370070576826684624621495650076471787294438377604532826541087568284431911906346940378552177792951453612327252500029607107508256381565671088525835072145876576172410976447339110607218265236877223636045174237069058518606604482076212098132878607339694128114266041808683061932846081119106155694051268969251934325451728388641918047049293215058642563049483624672216484350762017279180399446930047329563406911573244438690812579451408905770622942919710792820955037687525678773091862540744969844508330393682126183363848253301546861961243487676812975343759465158038628759287849020152168555482871720121925776695478182833757993103614740356856449095527097864797581167263201004368978425535399209318374414978068609844840309812907779179908821879532736447567559084803087086987551392711854517078544161852424320693150332599594068957565367821070749269665376763262354472106979395067965269474259770973916669376304263398708541052684708299085211399427365734116182760315001271653786073615010808570091499395125570281987460043753582903531743471732693212357815498262974255273730794953759765105305946966067683156574377167401875275889028025717332296191766687138199318110487701902712526768027607800301367868099252546340106163286652636270218540497705585629946580636237993140746255962240744869082311749777923654662572469233228109171419143028819710328859780666976089293863828502533340334413065578016127815921815005561868836468420090470230530811728164304876237919698424872550366387845831148769693215490281042402013833512446218144177347063783299490636259666498587618221225225512486764533677201869716985443124195724099139590089523100588229554825530026352078153229679624948164195386821877476085327132285723110424803456124867697064507995236377742425354112916842768655389262050249103265729672370191327572567528565324825826546309220705859652229798860272258331913126375147341994889534765745501184957014548792889848568277260777137214037988797153829820378303147352772158034814451349137322665138134829543829199918180278916522431027392251122869539409579530664052326325380441000596549391598795936352974615218550237130764225512118369380358038858490341698116222072977186158236678424689157993532961922624679571944012690438771072750481023908955235974572318970677254791506150550495392297953090112996751986188088225875314529584099251203829009407770775672113067397083047244838165338735023408456470580773088295917476714036319800818712901187549131054712658197623331044818386269515456334926366572897563400500428462801835170705278318394258821455212272512503275512160354698120058176216521282765275169129689778932238195734329339946437501907836945765883352399886755061649651847751807381688378610915273579297013376217784275219262340194239963916804498399317331273132924185707147349566916674687634660915035914677504995186714302352196288948901024233251169136196266227326746080059154747183079839286853520694694454072476841822524674417161514036427982273348055556214818971426179103425986472045168939894221798260880768528778364618279934631376775430780936333301898264209010848802521674670883215120185883543223812876952786713296124747824645386369930090493103636197638780396218407357239979422340623539380833965132740801111666627891981488087797941876876144230030984490851411606618262936828367647447792391803351109890697907148578694408955299065364044742557608365997664579509666024396409905389607120198219976047599490197230297649139826800329731560371200413779037855660850892521673093931987275027546890690370753941304265231501194809377245048795150954100921645863754710598436791786391670211874924319957006419179697775990283006991536871371193661495281130587638027841075444973307840789923115535562561142322423255033685442488917353448899115014406480203690680639606723221932041495354150312888033953605329934036800697771065056663195481234880673210146739058568557934581403627822703280826165707739483275922328459417065250945123252306082291880205877731971983945018088807242966198081119777158542502016545090413245809786882778948721859617721078384350691861554356628840622574736922845095162084960398013400172393067166682355524525280460972253503534226472524250874054075591789781264330331690";

            for (int i = 0; i < number.Length; i += digitLenth)
            {
                double t = Convert.ToDouble(number.Substring(i, digitLenth - 1).ToString());
                sum += Convert.ToInt64(number.Substring(i, digitLenth - 1).ToString());
            }

            return sum;
        }

        private string problem14_1()
        {
            Dictionary<double, double> dict = new Dictionary<double, double>();
            dict.Add(1, 1);
            KeyValuePair<double, double> answer = new KeyValuePair<double, double>(1, 1);
            double terms = 1;

            for (double startNum = 2; startNum <= 1000000; startNum++)
            {
                if (!dict.ContainsKey(startNum))
                {
                    terms = recursiveSequence(dict, startNum);
                    if (terms > answer.Value)
                        answer = new KeyValuePair<double, double>(startNum, terms);
                }
            }

            return string.Format("[StartNum, Terms] = {0}", answer.ToString());
        }
        private double recursiveSequence(Dictionary<double, double> dict, double startNum)
        {
            double nextTerm = 1;
            double steps = 0;
            //if the key exists, return the value
            if (dict.ContainsKey(startNum))
                return dict[startNum];

            if (startNum % 2 != 0)
                nextTerm = 3 * startNum + 1;
            else
                nextTerm = startNum / 2;

            steps = 1 + recursiveSequence(dict, nextTerm);
            dict.Add(startNum, steps);

            return steps;
        }

        private double problem15_1()
        {
            int level = 20;
            double routes = 0;
            List<KeyValuePair<int, List<double>>> rows = new List<KeyValuePair<int, List<double>>>();
            //build pascal's triangle to the level requested
            KeyValuePair<int, List<double>> row = buildPascalsTriangle(ref rows, level);

            //the number of routes equals the sum of the squares of each term in the requested row of 
            // pascal's triangle
            foreach (double term in row.Value)
                routes += (term * term);

            return routes;
        }
        private KeyValuePair<int, List<double>> buildPascalsTriangle(ref List<KeyValuePair<int, List<double>>> rows, int level)
        {
            KeyValuePair<int, List<double>> previousRow;
            KeyValuePair<int, List<double>> currentRow;

            //base row
            if (level == 0)
            {
                currentRow = new KeyValuePair<int, List<double>>(0, new List<double>() { 1 });
                rows.Add(currentRow);
            }
            //build row based on previous row
            else
            {
                previousRow = buildPascalsTriangle(ref rows, level - 1);
                currentRow = new KeyValuePair<int, List<double>>(level, new List<double>() { 1 });

                for (int i = 1; i < previousRow.Value.Count; i++)
                {
                    currentRow.Value.Add(previousRow.Value[i - 1] + previousRow.Value[i]);
                }
                currentRow.Value.Add(1);
                rows.Add(currentRow);
            }

            return currentRow;
        }
        
        private IntX problem16_1()
        {
            return IntX.Pow(2, 1000).SumOfDigits();
        }

        private int problem17_1()
        {
            int[] number = new int[4];
            int totalNumberOfLetters = 0;
            for (int i = 1; i <= 1000; i++)
            {
                number = _splitNumber(i);
                totalNumberOfLetters += getNumberOfLetters(number);
            }
            return totalNumberOfLetters;
        }
        private static int[] _splitNumber(int number)
        {
            int[] numbers = new int[4];

            numbers[0] = number / 1000;
            number %= 1000;

            numbers[1] = number / 100;
            number %= 100;

            numbers[2] = number / 10;
            number %= 10;

            numbers[3] = number;

            return numbers;
        }
        private static int getNumberOfLetters(int[] number)
        {
            int total = 0;
            if (number[0] != 0)
                total += getNumberOfLetters(number[0]) + getNumberOfLetters(1000);
            if (number[1] != 0)
                total += getNumberOfLetters(number[1]) + getNumberOfLetters(100);
            if (number[2] * 10 + number[3] < 9)
                total += getNumberOfLetters(number[3]);
            else if (number[2] * 10 + number[3] < 20)
                total += getNumberOfLetters(number[2] * 10 + number[3]);
            else
                total += getNumberOfLetters(number[2] * 10) + getNumberOfLetters(number[3]);

            int temp = number[0] * 1000 + number[1] * 100 + number[2] * 10 + number[3];
            if ((temp > 100) && (temp % 100 != 0))
                total += 3;     //add 3 for the word 'and'

            return total;
        }
        private static int getNumberOfLetters(int number)
        {
            int total = 0;
            switch (number)
            {
                case 1:
                case 2:
                case 6:
                case 10:
                    total = 3;
                    break;
                case 4:
                case 5:
                case 9:
                    total = 4;
                    break;
                case 3:
                case 7:
                case 8:
                case 40:
                case 50:
                case 60:
                    total = 5;
                    break;
                case 11:
                case 12:
                case 20:
                case 30:
                case 80:
                case 90:
                    total = 6;
                    break;
                case 15:
                case 16:
                case 70:
                case 100:
                    total = 7;
                    break;
                case 13:
                case 14:
                case 18:
                case 19:
                case 1000:
                    total = 8;
                    break;
                case 17:
                    total = 9;
                    break;
                default:
                    total = 0;
                    break;
            }
            return total;
        }

        private IntX problem20_1()
        {
            IntX number = 100;
            return number.Factorial().SumOfDigits();
        }

        #endregion

        #region Enumerations
        enum Directions { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }
        #endregion
    }
}
