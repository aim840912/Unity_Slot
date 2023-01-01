using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    public BoardVisual _boardVisual;
    public LineVisual _lineVisual;
    int[] _boardNum;
    Server _server = new SimulationServer();

    void GetGameBoardNum()
    {
        _boardNum = _server.GenerateGameBoardAndStore();
    }
    void Spin()
    {

    }

    void Stop()
    {

    }
}
