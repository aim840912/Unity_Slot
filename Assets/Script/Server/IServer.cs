public interface IServer
{
    int[] GenerateNum();
    int GetFinalMoney(int betMoney, out int odds);
}
