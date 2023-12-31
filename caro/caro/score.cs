using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caro
{
    public partial class frm_main : Form
    {
        //hàm xét điều kiện cho điểm từng trường hợp
        private int getBoradEval(int valuename, List<int> whotick, List<int> opponent)
        {
            int score = 50;
            if (fiveWin(valuename, whotick))
                score += 100000000;
            else if (liveFour(valuename, whotick, opponent))
                score += 15000000;
            else if (liveThreeSize(valuename, whotick, opponent) >= 2 || deadFourSize(valuename, whotick, opponent) == 2 ||
                    deadFourSize(valuename, whotick, opponent) == 1 && liveThreeSize(valuename, whotick, opponent) == 1)
                score += 10000000;
            else if (liveThreeSize(valuename, whotick, opponent) + jLiveThreeSỉze(valuename, whotick, opponent) == 2)
                score += 5000;
            //else if (jLiveThree(valuename, whotick, opponent))
            //    score += 2500;
            else if (deadFour(valuename, whotick, opponent))
                score += 1000;
            else if (jDeadFour(valuename, whotick, opponent))
                score += 300;
            //else
            //{
            //    score += scoreRow(valuename, whotick);
            //    score += scoreCol(valuename, whotick);
            //    score += scoreDiagonal(valuename, whotick);
            //    score += scoreAntiDiagonal(valuename, whotick);
            //}
            return score;
        }
        // hàm tính suy diễn cho nước đi thứ 2
        //private int getBoradEval(int passvaluename, int valuename)
        //{
        //    tickedListMachine.Add(passvaluename);
        //    List<int> whotick = tickedListPlayer.GetRange(0, tickedListPlayer.Count - 1);
        //    whotick.Add(valuename);
        //    if (fiveWin(valuename, whotick))
        //        return -100000;
        //    else if (liveFour(valuename, whotick))
        //        return -15000;
        //    else if (liveThreeSize(valuename, whotick) >= 2 || deadFourSize(valuename, whotick) == 2 ||
        //            deadFourSize(valuename, whotick) == 1 && liveThreeSize(valuename, whotick) == 1)
        //        return -10000;
        //    else if (liveThree(valuename, whotick) && jLiveThree(valuename, whotick))
        //        return -5000;
        //    else if (deadFour(valuename, whotick))
        //        return -1000;
        //    else if (jDeadFour(valuename, whotick))
        //        return -300;
        //    return 0;
        //}
        // hàm tính suy diễn cho nước đi thứ 3
        //private int getBoradEval(int overpassvaluename, int passvaluename, int valuename)
        //{
        //    tickedListPlayer.Add(passvaluename);
        //    List<int> whotick = tickedListMachine.GetRange(0, tickedListMachine.Count - 1);
        //    whotick.Add(overpassvaluename);
        //    whotick.Add(valuename);
        //    if (fiveWin(valuename, whotick))
        //        return 100000;
        //    else if (liveFour(valuename, whotick))
        //        return 15000;
        //    else if (liveThreeSize(valuename, whotick) >= 2 || deadFourSize(valuename, whotick) == 2 ||
        //            deadFourSize(valuename, whotick) == 1 && liveThreeSize(valuename, whotick) == 1)
        //        return 10000;
        //    else if (liveThree(valuename, whotick) && jLiveThree(valuename, whotick))
        //        return 5000;
        //    else if (deadFour(valuename, whotick))
        //        return 1000;
        //    else if (jDeadFour(valuename, whotick))
        //        return 300;
        //    return 0;
        //}
        //private int getBoradEvalOppoent(int overpassvaluename, int passvaluename, int valuename)
        //{
        //    tickedListMachine.Add(overpassvaluename);
        //    tickedListMachine.Add(valuename);
        //    List<int> whotick = tickedListPlayer.GetRange(0, tickedListPlayer.Count - 1);
        //    whotick.Add(passvaluename);
        //    if (fiveWin(valuename, whotick))
        //        return 100000;
        //    else if (liveFour(valuename, whotick))
        //        return 15000;
        //    else if (liveThreeSize(valuename, whotick) >= 2 || deadFourSize(valuename, whotick) == 2 ||
        //            deadFourSize(valuename, whotick) == 1 && liveThreeSize(valuename, whotick) == 1)
        //        return 10000;
        //    else if (liveThree(valuename, whotick) && jLiveThree(valuename, whotick))
        //        return 5000;
        //    else if (deadFour(valuename, whotick))
        //        return 1000;
        //    else if (jDeadFour(valuename, whotick))
        //        return 300;
        //    return 0;
        //}
        // ước lượng điểm cho các điểm tiềm năng
        //private List<int> potentialPointScore()
        //{
        //    List<int> scorelist = new List<int>();
        //    List<int> tickedpoint = findPotentialPoints();
        //    for (int i = 0; i < tickedpoint.Count; i++)
        //    {
        //        //MessageBox.Show(tickedpoint[i].ToString());
        //        int score = getBoradEval(tickedpoint[i]);
        //        scorelist.Add(score);
        //    }
        //    return scorelist;
        //}
        // ước lượng điểm cho các điểm gần điểm tiềm năng
        //private List<List<int>> nearPotentialPointScore()
        //{
        //    var list = new List<List<int>>();
        //    var nearpotentialpoint = findNearPotentialPoint();
        //    var potentialpoint = findPotentialPoints();
        //    var potentialscore = potentialPointScore();
        //    for (int i = 0; i < nearpotentialpoint.Count; i++)
        //    {
        //        List<int> scorelist = new List<int>();
        //        for (int j = 0; j < nearpotentialpoint[i].Count; j++)
        //        {
        //            list.Add(new List<int>());
        //            int score = getBoradEval(potentialpoint[i], nearpotentialpoint[i][j]) + potentialscore[i];
        //            tickedListMachine.RemoveAt(tickedListMachine.Count - 1);
        //            scorelist.Add(score);
        //        }
        //        list[i] = scorelist;
        //    }
        //    return list;
        //}
        // ước lượng điểm cho các điểm kề của các điểm kề các điểm tiềm năng
        //private List<List<int>> nearTickedTickedScore()
        //{
        //    var list = new List<List<int>>();
        //    List<List<List<int>>> nearnearpotentialpoint = findNearTickedTickedList();
        //    var potentialpoint = findPotentialPoints();
        //    var nearpotentialpoint = findNearPotentialPoint();
        //    var nearpotentialscore = nearPotentialPointScore();
        //    int alpha = int.MinValue, beta = int.MaxValue;

        //    for (int i = 0; i < nearnearpotentialpoint.Count; i++)
        //    {
        //        List<int> eachScore = new List<int>();
        //        for (int j = 0; j < nearnearpotentialpoint[i].Count; j++)
        //        {
        //            int max = getBoradEval(potentialpoint[i], nearpotentialpoint[i][j], nearnearpotentialpoint[i][j][0]);
        //            tickedListPlayer.RemoveAt(tickedListPlayer.Count - 1);
        //            for (int k = 0; k < nearnearpotentialpoint[i][j].Count; k++)
        //            {
        //                int score = 0 - getBoradEvalOppoent(potentialpoint[i], nearpotentialpoint[i][j], nearnearpotentialpoint[i][j][k]);
        //                tickedListMachine.RemoveRange(tickedListMachine.Count - 2, 2);
        //                int score2 = getBoradEval(potentialpoint[i], nearpotentialpoint[i][j], nearnearpotentialpoint[i][j][k]);
        //                score2 += score;
        //                tickedListPlayer.RemoveAt(tickedListPlayer.Count - 1);
        //                max = (score2 > max) ? score2 : max;
        //                alpha = (alpha > score2) ? alpha : score2;

        //                if (alpha >= beta)
        //                    break;
        //            }
        //            eachScore.Add(max);
        //            beta = max;
        //        }
        //        list.Add(new List<int>());
        //        list[i] = eachScore;
        //    }
        //    return list;
        //}
    }
}
