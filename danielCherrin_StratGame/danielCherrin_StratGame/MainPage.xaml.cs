using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace danielCherrin_StratGame
{
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<StratCell> gameCol00 = new ObservableCollection<StratCell>();
        public ObservableCollection<StratCell> gameCol01 = new ObservableCollection<StratCell>();
        public ObservableCollection<StratCell> gameCol02 = new ObservableCollection<StratCell>();
        public ObservableCollection<StratCell> gameCol03 = new ObservableCollection<StratCell>();
        public ObservableCollection<StratCell> gameCol04 = new ObservableCollection<StratCell>();


        public MainPage()
		{
			InitializeComponent();
            StartResetAppGrid();
            UIGridColumn00.ItemsSource = gameCol00;
            UIGridColumn01.ItemsSource = gameCol01;
            UIGridColumn02.ItemsSource = gameCol02;
            UIGridColumn03.ItemsSource = gameCol03;
            UIGridColumn04.ItemsSource = gameCol04;
        }

        public void StartResetAppGrid()
        {
            StratCell redCell = new StratCell();
            redCell.CellColor = Color.Red;
            redCell.CellUnits = 2;
            StratCell blueCell = new StratCell();
            blueCell.CellColor = Color.Blue;
            blueCell.CellUnits = 2;

            gameCol00.Add( redCell);
            gameCol00.Add( new StratCell());
            gameCol00.Add( new StratCell());
            gameCol00.Add( new StratCell());
            gameCol00.Add( new StratCell());

            gameCol01.Add( new StratCell());
            gameCol01.Add( new StratCell());
            gameCol01.Add( new StratCell());
            gameCol01.Add( new StratCell());
            gameCol01.Add( new StratCell());

            gameCol02.Add( new StratCell());
            gameCol02.Add( new StratCell());
            gameCol02.Add( new StratCell());
            gameCol02.Add( new StratCell());
            gameCol02.Add( new StratCell());

            gameCol03.Add( new StratCell());
            gameCol03.Add( new StratCell());
            gameCol03.Add( new StratCell());
            gameCol03.Add( new StratCell());
            gameCol03.Add( new StratCell());

            gameCol04.Add( new StratCell());
            gameCol04.Add( new StratCell());
            gameCol04.Add( new StratCell());
            gameCol04.Add( new StratCell());
            gameCol04.Add( blueCell);
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            Debug.WriteLine(e.Direction);
            StratCell swipedCell = e.Parameter as StratCell;

            Tuple<int,int> colAndIndex = new Tuple<int, int>(0,0);

            #region Find inside cols
            foreach (StratCell compareCell in gameCol00)
            {
                if (compareCell == swipedCell)
                {
                    colAndIndex = new Tuple<int, int>(0, gameCol00.IndexOf(compareCell));
                }
            }

            foreach (StratCell compareCell in gameCol01)
            {
                if (compareCell == swipedCell)
                {
                    colAndIndex = new Tuple<int, int>(1, gameCol01.IndexOf(compareCell));
                }
            }

            foreach (StratCell compareCell in gameCol02)
            {
                if (compareCell == swipedCell)
                {
                    colAndIndex = new Tuple<int, int>(2, gameCol02.IndexOf(compareCell));
                }
            }

            foreach (StratCell compareCell in gameCol03)
            {
                if (compareCell == swipedCell)
                {
                    colAndIndex = new Tuple<int, int>(3, gameCol03.IndexOf(compareCell));
                }
            }

            foreach (StratCell compareCell in gameCol04)
            {
                if (compareCell == swipedCell)
                {
                    colAndIndex = new Tuple<int, int>(4, gameCol04.IndexOf(compareCell));
                }
            }
            #endregion

            Debug.WriteLine("--------------");

            if(!(swipedCell.CellUnits <= 1))
            {
                //UpperLeft
                if (colAndIndex.Item1 == 0 &&
                    colAndIndex.Item2 == 0)
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Right:
                            gameCol01[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                            break;
                        case SwipeDirection.Down:
                            gameCol00[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                            break;
                    }
                }
                //UpperMiddle
                else if ((colAndIndex.Item1 == 1 &&
                    colAndIndex.Item2 == 0) || (colAndIndex.Item1 == 2 &&
                    colAndIndex.Item2 == 0) || (colAndIndex.Item1 == 3 &&
                    colAndIndex.Item2 == 0))
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Left:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol00[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol01[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol02[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }

                        case SwipeDirection.Right:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol02[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol03[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol04[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }

                        case SwipeDirection.Down:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol01[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol02[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol03[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                    }
                }
                //UpperRight
                else if (colAndIndex.Item1 == 4 &&
                    colAndIndex.Item2 == 0)
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Left:
                            gameCol03[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                            break;
                        case SwipeDirection.Down:
                            gameCol04[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                            break;
                    }
                }
                //MiddleLeft
                else if ((colAndIndex.Item1 == 0 &&
                    colAndIndex.Item2 == 1) || (colAndIndex.Item1 == 0 &&
                    colAndIndex.Item2 == 2) || (colAndIndex.Item1 == 0 &&
                    colAndIndex.Item2 == 3))
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Right:
                            if (colAndIndex.Item2 == 1)
                            {
                                gameCol01[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 2)
                            {
                                gameCol01[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 3)
                            {
                                gameCol01[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case SwipeDirection.Up:
                            if (colAndIndex.Item2 == 1)
                            {
                                gameCol00[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 2)
                            {
                                gameCol00[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 3)
                            {
                                gameCol00[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case SwipeDirection.Down:
                            if (colAndIndex.Item2 == 1)
                            {
                                gameCol00[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 2)
                            {
                                gameCol00[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 3)
                            {
                                gameCol00[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                    }
                }
                //MiddleMiddle
                else if ((colAndIndex.Item1 == 1 &&
                    colAndIndex.Item2 == 1) || (colAndIndex.Item1 == 1 &&
                    colAndIndex.Item2 == 2) || (colAndIndex.Item1 == 1 &&
                    colAndIndex.Item2 == 3) || (colAndIndex.Item1 == 2 &&
                    colAndIndex.Item2 == 1) || (colAndIndex.Item1 == 2 &&
                    colAndIndex.Item2 == 2) || (colAndIndex.Item1 == 2 &&
                    colAndIndex.Item2 == 3) || (colAndIndex.Item1 == 3 &&
                    colAndIndex.Item2 == 1) || (colAndIndex.Item1 == 3 &&
                    colAndIndex.Item2 == 2) || (colAndIndex.Item1 == 3 &&
                    colAndIndex.Item2 == 3))
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Left:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol00[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol01[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol02[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case SwipeDirection.Right:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol02[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol03[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol04[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case SwipeDirection.Up:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol01[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol02[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol03[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case SwipeDirection.Down:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol01[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol02[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol03[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                    }
                }
                //MiddleRight
                else if ((colAndIndex.Item1 == 4 &&
                    colAndIndex.Item2 == 1) || (colAndIndex.Item1 == 4 &&
                    colAndIndex.Item2 == 2) || (colAndIndex.Item1 == 4 &&
                    colAndIndex.Item2 == 3))
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Left:
                            if (colAndIndex.Item2 == 1)
                            {
                                gameCol03[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 2)
                            {
                                gameCol03[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 3)
                            {
                                gameCol03[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case SwipeDirection.Up:
                            if (colAndIndex.Item2 == 1)
                            {
                                gameCol04[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 2)
                            {
                                gameCol04[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 3)
                            {
                                gameCol04[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        case SwipeDirection.Down:
                            if (colAndIndex.Item2 == 1)
                            {
                                gameCol04[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 2)
                            {
                                gameCol04[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item2 == 3)
                            {
                                gameCol04[colAndIndex.Item2 + 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                    }
                }
                //BottomLeft
                else if((colAndIndex.Item1 == 0 &&
                    colAndIndex.Item2 == 4))
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Right:
                            gameCol01[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                            break;
                        case SwipeDirection.Up:
                            gameCol00[colAndIndex.Item2-1].BattleOnCell(ref swipedCell);
                            break;
                    }
                }
                //BottomMiddle
                else if((colAndIndex.Item1 == 1 &&
                    colAndIndex.Item2 == 4) || (colAndIndex.Item1 == 2 &&
                    colAndIndex.Item2 == 4) || (colAndIndex.Item1 == 3 &&
                    colAndIndex.Item2 == 4))
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Left:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol00[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol01[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol02[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }

                        case SwipeDirection.Right:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol02[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol03[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol04[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }

                        case SwipeDirection.Up:
                            if (colAndIndex.Item1 == 1)
                            {
                                gameCol01[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 2)
                            {
                                gameCol02[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else if (colAndIndex.Item1 == 3)
                            {
                                gameCol03[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                                break;
                            }
                            else
                            {
                                break;
                            }
                    }
                }
                //BottomRight
                else if ((colAndIndex.Item1 == 4 &&
                    colAndIndex.Item2 == 4))
                {
                    switch (e.Direction)
                    {
                        case SwipeDirection.Left:
                            gameCol03[colAndIndex.Item2].BattleOnCell(ref swipedCell);
                            break;
                        case SwipeDirection.Up:
                            gameCol04[colAndIndex.Item2 - 1].BattleOnCell(ref swipedCell);
                            break;
                    }
                }
            }
        }

        private void btn_Done_Clicked(object sender, EventArgs e)
        {
            #region Find inside cols
            foreach (StratCell compareCell in gameCol00)
            {
                compareCell.TurnIncrease();
            }

            foreach (StratCell compareCell in gameCol01)
            {
                compareCell.TurnIncrease();
            }

            foreach (StratCell compareCell in gameCol02)
            {
                compareCell.TurnIncrease();
            }

            foreach (StratCell compareCell in gameCol03)
            {
                compareCell.TurnIncrease();
            }

            foreach (StratCell compareCell in gameCol04)
            {
                compareCell.TurnIncrease();
            }
            #endregion
        }
    }
}
