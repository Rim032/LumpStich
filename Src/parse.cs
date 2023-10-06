using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace LumpStich
{
    public class Bsp_Lmp_Parser
    {
        public static List<string> lump_data_list = new List<string>();
        public static int[] duplicate_hammer_ids = new int[8192];
        public static bool bsp_has_lump_data = false;


        public bool compare_hammer_ids(string bsp_file, string lump_file)
        {
            if(bsp_file == null || lump_file == null)
            {
                return false;
            }
            const string hammer_id_regex_key = @"(hammerid).*?[\d]+";

            List<string> hammer_id_listA = new List<string>();
            List<string> hammer_id_listB = new List<string>();

            try
            {
                Regex lump_id_rgxA = new Regex(hammer_id_regex_key, RegexOptions.Singleline);
                foreach (Match lump_id_matchA in lump_id_rgxA.Matches(File.ReadAllText(bsp_file)))
                {
                    hammer_id_listA.Add(lump_id_matchA.ToString());
                }

                Regex lump_id_rgxB = new Regex(hammer_id_regex_key, RegexOptions.Singleline);
                foreach (Match lump_id_matchB in lump_id_rgxB.Matches(File.ReadAllText(lump_file)))
                {
                    hammer_id_listB.Add(lump_id_matchB.ToString());
                }
            }
            catch (Exception error)
            {
                return false;
            }

            int k = 0;
            foreach(string id_a in hammer_id_listA)
            {
                foreach(string id_b in hammer_id_listB)
                {
                    if (id_a == id_b)
                    {
                        duplicate_hammer_ids[k] = k;
                    }

                    if (duplicate_hammer_ids[k] > 0)
                    {
                        bsp_has_lump_data = true;
                    }

                    k++;
                }
            }

            return true;
        }

        public bool insert_lump_data(string bsp_file, Bsp_Header bsp_h)
        {
            if (bsp_file == null || bsp_h == null)
            {
                return false;
            }

            try
            {
                Byte[] bsp_file_bytes = File.ReadAllBytes(bsp_file);
                string[] lump_data_arr = lump_data_list.ToArray();  

                if (lump_data_arr == null)
                {
                    return false;
                }
                Stream bsp_write_file = File.Open(bsp_file.Replace(".bsp", "_s.bsp"), FileMode.Create);

                using (BinaryWriter lump_binary_writer = new BinaryWriter(bsp_write_file))
                {
                    for (long j = 0; j < bsp_file_bytes.Length; j++)
                    {
                        if (j == bsp_h.file_offset)
                        {
                            lump_binary_writer.Write(Encoding.ASCII.GetBytes(lump_data_arr[0]));
                            lump_binary_writer.Write(Encoding.ASCII.GetBytes("\n"));

                            for (int k = 1; k < lump_data_arr.Length; k++)
                            {
                                if (!bsp_has_lump_data && k != duplicate_hammer_ids[k])
                                {
                                    lump_binary_writer.Write(Encoding.ASCII.GetBytes(lump_data_arr[k]));
                                }
                                else if (bsp_has_lump_data)
                                {
                                    lump_binary_writer.Write(Encoding.ASCII.GetBytes(lump_data_arr[k]));
                                }

                                lump_binary_writer.Write(Encoding.ASCII.GetBytes("\n"));
                            }
                        }
                        else
                        {
                            if (j <= bsp_h.file_offset || j > (bsp_h.file_offset + bsp_h.file_length) - 2)
                            {
                                lump_binary_writer.Write(bsp_file_bytes[j]);
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                return false;
            }

            return true;
        }

        public bool gather_lump_data(string lump_file)
        {
            if(lump_file == null)
            {
                return false;
            }
            const string lump_chunk_regex_key = @"{[^}]+}"; //Regex key is taken from i-am-scott (https://github.com/i-am-scott)

            try
            {
                string file = File.ReadAllText(lump_file);
                Regex lump_chunk_rgx = new Regex(lump_chunk_regex_key, RegexOptions.Singleline);

                if (lump_chunk_rgx != null)
                {
                    foreach (Match lump_match in lump_chunk_rgx.Matches(file))
                    {
                        lump_data_list.Add(lump_match.ToString());
                    }
                    return true;
                }
            }
            catch (Exception error) 
            { }

            return false;
        }
    }

}