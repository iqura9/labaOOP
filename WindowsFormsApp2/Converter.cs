namespace WindowsFormsApp2
{
    public struct Index
    {
        public int row;
        public int column;
    }
    public class Converter
    {
        public static string To26System(int x)
        {
            x++;
            int mod;
            string columnName = "";
            if (x == 0) return ((char)64).ToString();
            while(x > 0)
            {
                mod = (x - 1) % 26;
                columnName = ((char)(65 + mod)).ToString() + columnName;
                x = (x - mod) / 26;
            }
            return columnName;
        }
        public static Index From26System ( string x)
        {
            Index res = new WindowsFormsApp2.Index();
            res.row = 0;
            res.column = 0;
            for(int i=0;i< x.Length; i++)
            {
                if(x[i] >= 64 && x[i] < 91)
                {
                    res.column *= 26;
                    res.column += x[i] - 64;
                }
                else if (x[i] >= 47 && x[i] < 58)
                {
                    res.row *= 10;
                    res.row += x[i] - 48;
                }
            }
            res.column--;
            return res;
        }

    }
}
