namespace TranHoangDieu_131
{
public class StringProcess_THD_131
{
    public string LowerToUpper(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            
            return "Invalid input";
        }
        else
        {
           
            return inputString.ToUpper();
        }
    }
}
}