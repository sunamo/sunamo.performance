public class FastStringLookup
{
    public const string StartingSearchingAHashSet = "Starting searching a HashSet... ";
    public const string StartingSearchingAHashSetWrapper = "Starting searching a HashSet... Wrapper ";

    public const string StartingSearchingAnArray = "Starting searching an array... ";
    public const string StartingSearchingAnArrayUsingTheCustomMethod = "Starting searching an array using the custom method... ";
    public const string StartingBinarySearchingAnArray = "Starting binary searching an array... ";
    public const string StartingSearchingAnArrayListUsingContains = "Starting searching an ArrayList using contains... ";
    public const string StartingSearchingAnArrayListUsingAForLoop = "Starting searching an ArrayList using a for loop... ";
    public const string StartingSearchingAListUsingContains = "Starting searching a List using Contains... ";
    public const string StartingSearchingAListUsingAForLoop = "Starting searching a List using a for loop... ";
    public const string StartingBinarySearchingAList = "Starting binary searching a List... ";
    public const string StartingSearchingASortedList = "Starting searching a SortedList... ";
    public const string StartingSearchingADictionaryKey = "Starting searching a Dictionary Key... ";
    public const string StartingSearchingADictionaryValue = "Starting searching a Dictionary Value... ";
    public const string StartingSearchingASortedDictionaryKey = "Starting searching a SortedDictionary Key... ";
    public const string StartingSearchingASortedDictionaryValue = "Starting searching a SortedDictionary Value... ";
    public const string StartingSearchingAConcurrentDictionaryKey = "Starting searching a ConcurrentDictionary Key... ";
    public const string StartingSearchingAConcurrentDictionaryValue = "Starting searching a ConcurrentDictionary Value... ";
    
    public const string StartingSearchingAHashTableKey = "Starting searching a HashTable Key... ";
    public const string StartingSearchingAHashTableValue = "Starting searching a HashTable Value... ";
    public const string StartingParallelSearchingAnArray = "Starting parallel searching an array... ";
    public const string StartingParallelSearchingAnArrayUsingCustomMethod = "Starting parallel searching an array using custom method... ";
    public const string StartingParallelBinarySearchingAnArray = "Starting parallel binary searching an array... ";
    public const string StartingParallelSearchingAnArrayListUsingContains = "Starting parallel searching an ArrayList using contains... ";
    public const string StartingParallelSearchingAnArrayListUsingAForLoop = "Starting parallel searching an ArrayList using a for loop... ";
    //double
    public const string StartingParallelSearchingAListUsingContains = "Starting parallel searching a List using contains... ";
    public const string StartingParallelBinarySearchingAList = "Starting parallel binary searching a List... ";
    public const string StartingParallelSearchingASortedList = "Starting parallel searching a SortedList... ";
    public const string StartingParallelSearchingADictionaryKey = "Starting parallel searching a Dictionary Key... ";
    public const string StartingParallelSearchingADictionaryValue = "Starting parallel searching a Dictionary Value... ";
    public const string StartingParallelSearchingASortedDictionaryKey = "Starting parallel searching a SortedDictionary Key... ";
    public const string StartingParallelSearchingASortedDictionaryValue = "Starting parallel searching a SortedDictionary Value... ";
    public const string StartingParallelSearchingConcurrentDictionaryKey = "Starting parallel searching ConcurrentDictionary key... ";
    public const string StartingParallelSearchingConcurrentDictionaryValue = "Starting parallel searching ConcurrentDictionary value... ";
    public const string StartingParallerSearchingAHashSet = "Starting paraller searching a HashSet... ";
    public const string StartingParallelSearchingAHashTableKey = "Starting parallel searching a HashTable Key... ";
    public const string StartingParallelSearchingAHashTableValue = "Starting parallel searching a HashTable Value... ";



    static Dictionary<string, TimeSpan> e = new Dictionary<string, TimeSpan>();
    static TimeSpan diff = TimeSpan.Zero;
    public static void TestFastestStructureForStringLookup()
    {
        DateTime end;
        DateTime start = DateTime.Now;

        Console.WriteLine("### Overall Start Time: " + start.ToLongTimeString());
        Console.WriteLine();

        #region TestFastestStructureForStringLookup
        //Fastest string lookup
        //TestFastestStructureForStringLookup(1, 12);
        //TestFastestStructureForStringLookup(100, 12);
        //TestFastestStructureForStringLookup(100, 50);
        //TestFastestStructureForStringLookup(100, 128);
        //TestFastestStructureForStringLookup(5000, 12);
        //TestFastestStructureForStringLookup(5000, 50);
        //TestFastestStructureForStringLookup(5000, 128);
        //TestFastestStructureForStringLookup(25000, 12);
        //TestFastestStructureForStringLookup(25000, 50);
        //TestFastestStructureForStringLookup(25000, 128);
        //TestFastestStructureForStringLookup(100000, 12);
        //TestFastestStructureForStringLookup(100000, 50);
        //TestFastestStructureForStringLookup(100000, 128);

        int NumberOfStringsToGenerate = 10000;
        int LengthOfStrings = 12;
        //TestFastestStructureForStringLookup(NumberOfStringsToGenerate, LengthOfStrings);
        HashSetTest(NumberOfStringsToGenerate, LengthOfStrings);
        HashSetTestObject(NumberOfStringsToGenerate, LengthOfStrings);
        #endregion

        var ordered = e.OrderBy(d => d.Value);
        StringBuilder sb = new StringBuilder();
        foreach (var item in ordered)
        {
            sb.AppendLine(item.Value + " " + item.Key);
        }
        TF.WriteAllText(@"D:\Desktop\output.txt", sb.ToString());

        end = DateTime.Now;
        Console.WriteLine();
        Console.WriteLine("### Overall End Time: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("### Overall Run Time: " + diff);
        //e.Add(, diff);

        Console.WriteLine();
        Console.WriteLine("Hit Enter to Exit");
        Console.ReadLine();

    }

    static int total = 0;
    static DateTime start = DateTime.MinValue;
    static DateTime end = DateTime.MinValue;


    private static void HashSetTest(int NumberOfStringsToGenerate, int LengthOfStrings)
    {
        string temp_str = null;
        string[] ss = new string[NumberOfStringsToGenerate];

        HashSet<string> hs = new HashSet<string>();
        for (int x = 0; x < NumberOfStringsToGenerate; x++)
        {
            ss[x] = RandomStringHelper.RandomString(LengthOfStrings, x % 5);

            if (x % 3 == 0)
                temp_str = ss[x]; //to ensure there's always at least a few matches
            else
                temp_str = RandomStringHelper.RandomString(LengthOfStrings, x % 5);

            hs.Add(temp_str);
        }

        total = 0;
        Console.WriteLine(StartingSearchingAHashSet);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (hs.Contains(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAHashSet, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000);
    }

    private static void HashSetTestObject(int NumberOfStringsToGenerate, int LengthOfStrings)
    {
        WrapperStringObject temp_str = null;
        WrapperStringObject[] ss = new WrapperStringObject[NumberOfStringsToGenerate];

        HashSet<WrapperStringObject> hs = new HashSet<WrapperStringObject>();
        for (int x = 0; x < NumberOfStringsToGenerate; x++)
        {
            ss[x] = new WrapperStringObject( RandomStringHelper.RandomString(LengthOfStrings, x % 5));

            if (x % 3 == 0)
                temp_str = ss[x]; //to ensure there's always at least a few matches
            else
                temp_str = new WrapperStringObject( RandomStringHelper.RandomString(LengthOfStrings, x % 5));

            hs.Add( temp_str);
        }

        total = 0;
        Console.WriteLine(StartingSearchingAHashSetWrapper);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (hs.Contains( ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAHashSetWrapper, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000);
    }

    const int los = 128;

    //what is the fastest structure to lookup a string?
    //hashset.contains
    //dictionary key
    //concurrent dictionary key
    //sorted dictionary
    //list.containsvalue
    //array
    static void TestFastestStructureForStringLookup(int NumberOfStringsToGenerate, int LengthOfStrings)
    {
        Console.WriteLine("######## " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        Console.WriteLine("Number of Random Strings that will be generated: " + NumberOfStringsToGenerate.ToString("#,##0"));
        Console.WriteLine("Length of Random Strings that will be generated: " + LengthOfStrings.ToString("#,##0"));
        Console.WriteLine();

        object lockObject = new object();
        int total = 0;
        DateTime end = DateTime.Now;
        DateTime start = DateTime.Now;
        string temp_str = String.Empty;

        string[] a = new string[NumberOfStringsToGenerate];
        string[] a_bs = new string[NumberOfStringsToGenerate];  //for a binary search
        List<string> l = new List<string>(NumberOfStringsToGenerate);
        List<string> l_bs = new List<string>(NumberOfStringsToGenerate); //for binary search
        SortedList<string, string> sl = new SortedList<string, string>(NumberOfStringsToGenerate);
        ArrayList al = new ArrayList(NumberOfStringsToGenerate);
        Dictionary<string, string> d = new Dictionary<string, string>(NumberOfStringsToGenerate);
        ConcurrentDictionary<string, string> cd = new ConcurrentDictionary<string, string>(Environment.ProcessorCount, NumberOfStringsToGenerate);
        SortedDictionary<string, string> sd = new SortedDictionary<string, string>();
        HashSet<string> hs = new HashSet<string>();
        Hashtable ht = new Hashtable(NumberOfStringsToGenerate);

        //the strings to look up
        string[] ss = new string[NumberOfStringsToGenerate];

        //Generate the string arrays that all the structures will read from.
        //This is to make sure every structure uses the same set of strings during the run.
        //strings to be searched. Completely random. Using generate password method to come up with all sorts of mixtures.
        Console.WriteLine("Generating strings to look up.");
        for (int x = 0; x < NumberOfStringsToGenerate; x++)
        {
            ss[x] = RandomStringHelper.RandomString(LengthOfStrings, x % 5);

            if (x % 3 == 0)
                temp_str = ss[x]; //to ensure there's always at least a few matches
            else
                temp_str = RandomStringHelper. RandomString(LengthOfStrings, x % 5);

            //so all the collections have the exact same strings.
            a[x] = temp_str;
            a_bs[x] = temp_str;
            al.Add(temp_str);
            l.Add(temp_str);
            l_bs.Add(temp_str);
            sl.Add(temp_str, temp_str);
            if (!d.ContainsKey(temp_str))
            {
                d.Add(temp_str, temp_str);
                sd.Add(temp_str, temp_str);
                cd[temp_str] = temp_str;
            }
            hs.Add(temp_str);
            ht.Add(temp_str, temp_str);
        }
        Array.Sort(a_bs);   //presort the binarysearch array as otherwise the results may be incorrect.
        l_bs.Sort();    //presort 

        Console.WriteLine("###########################################################");
        Console.WriteLine();

        total = 0;
        Console.WriteLine(StartingSearchingAnArray + start.ToLongTimeString());
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            for (int y = 0; y < a.Length; y++)
            {
                if (a[y].Contains(ss[x]))
                {   //found it.
                    total += 1;
                    break;
                }
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAnArray, diff);

        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAnArrayUsingTheCustomMethod + start.ToLongTimeString());
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            for (int y = 0; y < a.Length; y++)
            {
                if ((ss[x].Length - ss[x].Replace(a[y], String.Empty).Length) / a[y].Length > 0)
                {   //found it.
                    total += 1;
                    break;
                }
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAnArrayUsingTheCustomMethod, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingBinarySearchingAnArray + start.ToLongTimeString());
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            int y = Array.BinarySearch(a_bs, ss[x]); if (y >= 0)
                total += 1;
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingBinarySearchingAnArray, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAnArrayListUsingContains);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (al.Contains(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAnArrayListUsingContains, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAnArrayListUsingAForLoop);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            for (int y = 0; y < al.Count; y++)
            {
                if (al[y] == ss[x])
                {   //found it.
                    total += 1;
                    break;
                }
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAnArrayListUsingAForLoop, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAListUsingContains);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (l.Contains(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAListUsingContains, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAListUsingAForLoop);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            for (int y = 0; y < l.Count; y++)
            {
                if (l[y] == ss[x])
                {   //found it.
                    total += 1;
                    break;
                }
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAListUsingAForLoop, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingBinarySearchingAList);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            int y = l_bs.BinarySearch(ss[x]); if (y >= 0)
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingBinarySearchingAList, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingASortedList);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (sl.ContainsKey(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingASortedList, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingADictionaryKey);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (d.ContainsKey(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingADictionaryKey, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingADictionaryValue);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (d.ContainsValue(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingADictionaryValue, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingASortedDictionaryKey);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (sd.ContainsKey(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingASortedDictionaryKey, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingASortedDictionaryValue);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (sd.ContainsValue(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingASortedDictionaryValue, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAConcurrentDictionaryKey);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (cd.ContainsKey(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAConcurrentDictionaryKey, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAConcurrentDictionaryValue);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (cd.Values.Any(z => z == ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAConcurrentDictionaryValue, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAHashSet);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (hs.Contains(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAHashSet, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAHashTableKey);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (ht.ContainsKey(ss[x]))
            {   //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAHashTableKey, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingSearchingAHashTableValue);
        start = DateTime.Now;
        for (int x = 0; x < ss.Length; x++)
        {
            if (ht.ContainsValue(ss[x]))
            {
                //found it.
                total += 1;
            }
        }
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingSearchingAHashTableValue, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine("#########Starting the parallel implementations#############");
        Console.WriteLine("############################################################");
        total = 0;
        Console.WriteLine(StartingParallelSearchingAnArray + start.ToLongTimeString());
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
                () => 0,
                (x, loopState, subtotal) =>
                {
                    for (int y = 0; y < a.Length; y++)
                    {
                        if (a[y].Contains(ss[x]))
                        {   //found it.
                        subtotal += 1;
                            break;
                        }
                    }
                    return subtotal;
                },
                                    (s) =>
                                    {
                                        lock (lockObject)
                                        {
                                            total += s;
                                        }
                                    }
                );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingAnArray, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingAnArrayUsingCustomMethod + start.ToLongTimeString());
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                for (int y = 0; y < a.Length; y++)
                {
                    if ((ss[x].Length - ss[x].Replace(a[y], String.Empty).Length) / a[y].Length > 0)
                    {   //found it.
                            subtotal += 1;
                        break;
                    }
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingAnArrayUsingCustomMethod, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelBinarySearchingAnArray + start.ToLongTimeString());
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                int y = Array.BinarySearch(a_bs, ss[x]);
                if (y >= 0)
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelBinarySearchingAnArray, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingAnArrayListUsingContains);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (al.Contains(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingAnArrayListUsingContains, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingAnArrayListUsingAForLoop);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                for (int y = 0; y < al.Count; y++)
                {
                    if (al[y] == ss[x])
                    {   //found it.
                            subtotal += 1;
                        break;
                    }
                }
                return subtotal;
            },
                    (s) =>
                    {
                        lock (lockObject)
                        {
                            total += s;
                        }
                    }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingAnArrayListUsingAForLoop, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingAListUsingContains);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                for (int y = 0; y < l.Count; y++)
                {
                    if (l[y] == ss[x])
                    {   //found it.
                            total += 1;
                        break;
                    }
                }
                return subtotal;
            },
                        (s) =>
                        {
                            lock (lockObject)
                            {
                                total += s;
                            }
                        }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
       e.Add(StartingParallelSearchingAListUsingContains, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelBinarySearchingAList);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                int y = l_bs.BinarySearch(ss[x]);
                if (y >= 0)
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelBinarySearchingAList, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingASortedList);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (sl.ContainsKey(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingASortedList, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingADictionaryKey);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (d.ContainsKey(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingADictionaryKey, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingADictionaryValue);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (d.ContainsValue(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingADictionaryValue, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingASortedDictionaryKey);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (sd.ContainsKey(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingASortedDictionaryKey, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingASortedDictionaryValue);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (sd.ContainsValue(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingASortedDictionaryValue, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingConcurrentDictionaryKey);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (cd.ContainsKey(ss[x]))
                    subtotal += 1;

                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingConcurrentDictionaryKey, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingConcurrentDictionaryValue);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (cd.Values.Any(z => z == ss[x]))
                    subtotal += 1;

                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallelSearchingConcurrentDictionaryValue, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallerSearchingAHashSet);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (hs.Contains(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        e.Add(StartingParallerSearchingAHashSet, diff);
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingAHashTableKey);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (ht.ContainsKey(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff); if (LengthOfStrings == los)
        {
            e.Add(StartingParallelSearchingAHashTableKey, diff);
        }
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Thread.Sleep(1000); //Sleep to give the system time to recover for next run

        total = 0;
        Console.WriteLine(StartingParallelSearchingAHashTableValue);
        start = DateTime.Now;
        Parallel.For(0, ss.Length,
            () => 0,
            (x, loopState, subtotal) =>
            {
                if (ht.ContainsValue(ss[x]))
                {   //found it.
                        subtotal += 1;
                }
                return subtotal;
            },
            (s) =>
            {
                lock (lockObject)
                {
                    total += s;
                }
            }
        );
        end = DateTime.Now;
        Console.WriteLine("Finished at: " + end.ToLongTimeString());
        diff = (end - start);
        Console.WriteLine("Time: " + diff);
        if (LengthOfStrings == los)
        {
            e.Add(StartingParallelSearchingAHashTableValue, diff);
        }
        Console.WriteLine("Total finds: " + total + Environment.NewLine);
        Console.WriteLine();
        Console.WriteLine("###########################################################");
        Console.WriteLine();

        Array.Clear(ss, 0, ss.Length);
        ss = null;
        Array.Clear(a, 0, a.Length);
        a = null;
        al.Clear();
        al = null;
        l.Clear();
        l = null;
        l_bs.Clear();
        l_bs = null;
        sl.Clear();
        sl = null;
        d.Clear();
        d = null;
        sd.Clear();
        sd = null;
        cd.Clear();
        cd = null;
        hs.Clear();
        hs = null;
        ht.Clear();
        ht = null;

        GC.Collect();



    } //TestFastestStructureForStringLookup


}
