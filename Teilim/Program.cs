using System;
using System.Collections.Generic;

namespace Psalms//לשבת על פרק קיט ולתעד...
{
    
    class Program
    {
        /// <summary>
        /// פונקציה המחזירה חלוקה מדויקת של התהילים לפי מספר האנשים המעונינים לומר. יש להבחין ולבחר את האפשרות עם ההפרש הגדול ביותר בין הגדול לקטן
        /// </summary>
        /// <param name="numOfPeople">מספר האנשים האומרים את פרקי התהילים</param>
        /// 

        public static void printTeilimParts(int numOfPeople)
        {
            {


                //int i = 150;//מספר פרקי התהילים
                //i--;//לצורך חישוב אינדסאלי
                int[] seferTeilim =
                {
                6,12,9,9,13,10,18,10,21,18,
                7,9,6,7,5,11,15,51,15,10,
                14,32,6,10,22,12,13,9,11,13,
                25,11,22,23,28,13,40,23,14,18,
                14,12,5,27,18,12,10,15,21,
                23,21,11,7,9,24,14,12,12,18,
                14,9,13,12,11,14,20,8,36,37,
                6,24,20,28,23,11,13,21,72,13,
                20,17,8,19,13,14,17,7,19,53,
                17,16,16,5,23,11,13,11,9,9,
                5,8,29,22,35,45,48,43,14,31,
                7,10,10,9,8,18,19,2,29,
                8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,
                7,8,9,4,8,5,6,5,6,8,
                8,3,18,3,3,21,26,9,8,
                24,14,10,8,12,15,21,10,20,14,9,6
                };//ספר התהילים כאשר נוספים 21 פרקים חדשים, כנגד אותיות קיט למען הווית חלוקה מדויקת יותר
                // Array.Reverse(seferTeilim);//אולי החישוב ישתפר עם רוורס המערך לבדק
                // בחינת 2 המערכים: לסדר אותם בסדר עולה ולראות מה רמת ההפרש מהחציון
                // לבחור את סכום ההפרשים מהחציון הנמוך ביותר
                //או את הגדול והקטן הקרובים ביותר

                Range[] prakimRange = new Range[numOfPeople];//מערך טווח הפרקים
                int i; int psukimCount = 0;
                bool flagMore = false;

                for (i = 0; i < seferTeilim.Length; i++)//מנית מספר הפסוקים בתהילים
                {
                    psukimCount += seferTeilim[i];
                }
                //Console.WriteLine(" מספר הפסוקים בתהילים: " + psukimCount);//מספר הפסוקים בכל התהילים
                double avg1 = Convert.ToDouble(psukimCount) / Convert.ToDouble(numOfPeople);
                int avg = Convert.ToInt32(Math.Round(avg1));//ממוצע מועגל למספר הקרוב ביותר
                //Console.WriteLine(" מספר הפסוקים הממוצע: " + avg);//ממוצע התהילים לבן אדם
                Console.WriteLine("שים לב, יש לומר את מספר הפסוקים כולל האות הראשונה והאות האחרונה! ");

                for (i = 0; i < prakimRange.Length; i++)
                {
                    prakimRange[i] = new Range();//איתחול כל איברי מערך הטווחים
                }

                prakimRange[prakimRange.Length - 1].To = 149 + 21;//איתחול הפרק האחרון
                prakimRange[0].From = 0;//הפרק הראשון שיאמר יהיה 0
                int j = numOfPeople - 1;//מספר האנשים אינדקסאלי
                int count = 0;//מנית מספר פרקי התהילים לבן אדם

               
                 int countAll = 0;//מנית כל הפרקים
                i = 149 + 21;//. הפרק האחרון
                while (j > 0)//כל עוד לא הגענו לאדם אחד לפני האחרון. האחרון בסריקה שהוא הראשון, מקבל את מה שנשאר בדיוק
                {

                    count = 0;//מנית מספר הפסוקים הנוכחי

                    for (; i > 0 && count < avg; i--)//כל עוד מספר הפסוקים קטן מהממוצע וגם נותרו פסוקים
                    {
                        count += seferTeilim[i];
                    }

                    int diffWithoutLast = 0;
                    int diff = avg - count;//ההפרש
                    diff = Math.Abs(diff);

                    if (diff == 0)//מספר פרקי התהילים כמו הממוצע
                    {
                        countAll += count;
                        prakimRange[j].Count = count;
                        prakimRange[j].From = i + 1;
                        prakimRange[--j].To = i;

                    }

                    else
                    {
                        if (i > 0)
                            count -= seferTeilim[i + 1];
                        diffWithoutLast = avg - count;//מספר פרקי התהילים לא כולל האחרון
                        
                        if (diff < diffWithoutLast)//הקרבה לממוצע כאשר אומרים גם פרק התהילים האחרון
                        {
                            prakimRange[j].Count = count + seferTeilim[i + 1];
                            countAll += count + seferTeilim[i + 1];
                            prakimRange[j].From = i + 1;
                            prakimRange[--j].To = i;

                        }
                        else//הקרבה לממוצע כאשר אין למנות את פרק התהילים האחרון
                        {

                            prakimRange[j].Count = count;
                            countAll += count;
                            prakimRange[j].From = i + 2;
                            prakimRange[--j].To = i + 1;
                            i++;
                        }
                    }
                }
                //for (int l = 10; l < 151; l++)//הדפסות לנוחות
                //{
                //    Console.Write("{" + (l) + ",\"\"},");
                //}

                Dictionary<int, int> perek119 = new Dictionary<int, int>
                    {
                        {119,1},{120,2},{121,3},{122,4},{123,5},{124,6},{125,7},{126,8},{127,9},{128,10},{129,11},{130,12},{131,13},{132,14},{133,15},{134,16},{135,17},{136,18},{137,19},{138,20},{139,21},{140,22},
                    };//פרק קיט, מיקום במערך ספר התהילים וקבלת האות ממוספר 1 עד 22

                int firstOt, lastOt;
                Dictionary<int, string> perekToOt119 = new Dictionary<int, string> { { 1, "א" }, { 2, "ב" }, { 3, "ג" }, { 4, "ד" }, { 5, "ה" }, { 6, "ו" }, { 7, "ז" }, { 8, "ח" }, { 9, "ט" },{10,"י"},{11,"כ"},{12,"ל"},{13,"מ"},{14,"נ"},{15,"ס"},{16,"ע"},{17,"פ"},{18,"צ"},{19,"ק"},{20,"ר"},{21,"ש"},{22,"ת"}
                    };//פרק קיט, קבלת האות המתאימה עבור מספר מ1 עד 22, מא עד תו.
                Dictionary<int, string> perekToOt = new Dictionary<int, string> { { 1, "א" }, { 2, "ב" }, { 3, "ג" }, { 4, "ד" }, { 5, "ה" }, { 6, "ו" }, { 7, "ז" }, { 8, "ח" }, { 9, "ט" },{10,"י"},{11,"יא"},{12,"יב"},{13,"יג"},{14,"יד"},{15,"טו"},{16,"טז"},{17,"יז"},{18,"יח"},{19,"יט"},{20,"כ"},{21,"כא"},{22,"כב"},{23,"כג"},{24,"כד"},{25,"כה"},{26,"כו"},{27,"כז"},{28,"כח"},{29,"כט"},{30,"ל"},{31,"לא"},{32,"לב"},
                        { 33,"לג"},{34,"לד"},{35,"לה"},{36,"לו"},{37,"לז"},{38,"לח"},{39,"לט"},{40,"מ"},{41,"מא"},{42,"מב"},{43,"מג"},{44,"מד"},{45,"מה"},{46,"מו"},{47,"מז"},{48,"מח"},{49,"מט"},{50,"נ"},{51,"נא"},{52,"נב"},{53,"נג"},{54,"נד"},{55,"נה"},{56,"נו"},{57,"נז"},{58,"נח"},{59,"נט"},{60,"ס"},{61,"סא"},{62,"סב"},{63,"סג"},{64,"סד"},{65,"סה"},{66,"סו"},{67,"סז"},{68,"סח"},{69,"סט"},{70,"ע"},{71,"עט"},{72,"עב"},{73,"עג"},{74,"עד"},{75,"עה"},{76,"עו"},{77,"עז"},{78,"עח"},{79,"עט"},{80,"פ"},{81,"פא"},{82,"פב"},{83,"פג"},{84,"פד"},{85,"פה"},{86,"פו"},{87,"פז"},{88,"פח"},{89,"פט"},{90,"צ"},{91,"צא"},{92,"צב"},{93,"צג"},{94,"צד"},{95,"צה"},{96,"צו"},{97,"צז"},{98,"צח"},{99,"צט"},{100,"ק"},{101,"קא"},{102,"קב"},{103,"קג"},{104,"קד"},{105,"קה"},{106,"קו"},{107,"קז"},{108,"קח"},{109,"קט"},{110,"קי"},{111,"קיא"},{112,"קיב"},{113,"קיג"},{114,"קיד"},{115,"קטו"},{116,"קטז"},{117,"קיז"},{118,"קיח"},{119,"קיט"},{120,"קכ"},{121,"קכא"},{122,"קכב"},{123,"קכג"},{124,"קכד"},{125,"קכה"},{126,"קכו"},{127,"קכז"},{128,"קכח"},{129,"קכט"},{130,"קל"},{131,"קלא"},{132,"קלה"},{133,"קלג"},{134,"קלד"},{135,"קלה"},{136,"קלו"},{137,"קלז"},{138,"קלח"},{139,"קלט"},{140,"קמ"},
                        { 141,"קמא"},{142,"קמב"},{143,"קמג"},{144,"קמד"},{145,"קמה"}
                        ,{146,"קמו"},{147,"קמז"},{148,"קמח"},{149,"קמט"},{150,"קנ"}
                    };//מילון לקבלת פרק התהילים המתאים, מא עד קנ
                string fromPerek, toPerek, from119, to119;//משתני אאוט לקבלת ערכי המילונים

               prakimRange[j].Count = psukimCount - countAll;//מספר הפסוקים בפרק האחרון לסריקה

                i = 0;

                //סריקת שיפור הפרקים, עבור כל 3 פרקים ברצף עד 2 האחרונים

                for (int l = 0; l < numOfPeople - 2; l++)
                {
                    int all3people = prakimRange[l].Count + prakimRange[l + 1].Count + prakimRange[l + 2].Count;//סכום 3 הפרקים הקרובים
                    double avg3people1 = Convert.ToDouble(all3people) / Convert.ToDouble(3);//ממוצע 3 האחרונים
                    int avg3people = Convert.ToInt32(Math.Round(avg3people1));//עיגול כלפי מעלה או מטה

                    count = 0;

                    j = 0;

                    while (j < 3)
                    {
                        for (i = prakimRange[l].From; i <= prakimRange[l + 2].To && count < avg3people; i++)
                        {
                            count += seferTeilim[i];
                        }

                        int h2 = 0;
                        int h1 = avg3people - count;
                        if (h1 == 0)
                        {
                            countAll += count;
                            prakimRange[l + j].Count = count;

                            prakimRange[l + j++].To = i;
                            if(l+j!=numOfPeople)
                                 prakimRange[l + (j)].From = i + 1;

                        }

                        else
                        {
                            if (i > 0)
                                count -= seferTeilim[i - 1];
                            h2 = avg3people - count;//new
                            h1 = Math.Abs(h1);
                            if (h1 < h2)//prefer regulari...
                            {
                                prakimRange[l + j].Count = count + seferTeilim[i + 1];


                                prakimRange[l + j++].To = i;
                                if (l+j  != numOfPeople)
                                    prakimRange[l + (j)].From = i + 1;

                            }
                            else
                            {

                                prakimRange[l + j].Count = count;

                                prakimRange[l + j++].To = i - 1;
                                if (l +j != numOfPeople)
                                    prakimRange[l + (j)].From = i;
                                i++;
                            }
                        }
                    }
                }
                //הדפסת הפסוקים המתאימים, בהתחשב בפרק קיט
                for (i = 0; i < prakimRange.Length; i++)
                {
                    prakimRange[i].From = prakimRange[i].From + 1;
                    prakimRange[i].To = prakimRange[i].To + 1;
                    int from = prakimRange[i].From;
                    int to = prakimRange[i].To;

                    if (from < 119 && to < 119)//כאשר הפרקים קטנים מקיט יש להדפיס כרגיל
                    {
                        perekToOt.TryGetValue(prakimRange[i].From, out fromPerek);
                        perekToOt.TryGetValue(prakimRange[i].To, out toPerek);

                        Console.WriteLine("יהודי מספר   " + (i + 1) + " צריך לומר מפרק : " + (fromPerek) + " עד פרק " + (toPerek) + " ! זכור, מדובר ב " + prakimRange[i].Count + " פסוקים.");
                    }
                    else
                    {
                        if (from > 119 + 21)//כאשר הפרקים גדולים מקיט יש להדפיס בהפחתת 21 פרקים מיותרים עבור האותיות הנוספות
                        {
                            from -= 21;
                            to -= 21;
                            perekToOt.TryGetValue(from, out fromPerek);
                            perekToOt.TryGetValue(to, out toPerek);


                            Console.WriteLine("יהודי מספר " + (i + 1) + " צריך לומר את הפרקים הבאים, מ: " + fromPerek + " עד " + toPerek + " ! זכור, מדובר ב " + prakimRange[i].Count + " פסוקים.");
                        }
                        else//כאשר חלק מהפרקים מקיט
                        {
                            if (from >= 119 && to <= (119 + 21))//כאשר כל הפסוקים מקיט
                            {

                                perek119.TryGetValue(from, out firstOt);
                                perek119.TryGetValue(to, out lastOt);

                                perekToOt.TryGetValue(from, out fromPerek);
                                perekToOt.TryGetValue(to, out toPerek);
                                perekToOt119.TryGetValue(firstOt, out from119);
                                perekToOt119.TryGetValue(lastOt, out to119);

                                Console.WriteLine("יהודי מספר " + (i + 1) + " צריך לומר את הפרקים הבאים, מ קיט אות:  " + from119 + " עד האות : " + to119 + " ! זכור, מדובר ב " + prakimRange[i].Count + " פסוקים.");
                            }
                            else
                            {
                                //קיט נמצא בטווח של ההתחלה/סוף/אמצע
                                Console.Write("יהודי מספר " + (i + 1) + " צריך לומר את הפרקים הבאים, מ: ");

                                if (from < 119)//כאשר מתחילים מפרק קודם לקיט
                                {
                                    perekToOt.TryGetValue(from, out fromPerek);

                                    Console.Write(fromPerek + " עד  ");
                                }
                                else//כאשר מתחילים מפרק קיט
                                {
                                    perek119.TryGetValue(from, out firstOt);

                                    perekToOt119.TryGetValue(firstOt, out from119);

                                    Console.Write(" מפרק קיט אות: " + from119 + " עד ");
                                }

                                if (to > 119 + 21)//כאשר הפרק בו מסימים גדול מקיט
                                {

                                    perekToOt.TryGetValue((to - 21), out toPerek);


                                    Console.Write(toPerek);
                                }
                                else//כאשר מסימים בפרק קיט
                                {
                                    perek119.TryGetValue(to, out lastOt);

                                    perekToOt119.TryGetValue(lastOt, out to119);

                                    Console.Write("פרק קיט אות:  " + to119);
                                }



                                Console.WriteLine(" ! זכור, מדובר ב " + prakimRange[i].Count + " פסוקים.");

                            }
                        }
                    }


                }
            }

        }



        static void Main(string[] args)
        {

            printTeilimParts(4);


        }
    }
}
