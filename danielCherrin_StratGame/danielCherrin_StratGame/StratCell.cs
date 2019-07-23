using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace danielCherrin_StratGame
{
    public class StratCell : INotifyPropertyChanged
    {
        private int _CellUnits = 0;
        public int CellUnits
        {
            get { return _CellUnits; }
            set
            {
                _CellUnits = value;
                OnPropertyChanged("CellUnits");
            }
        }

        private Color _CellColor = Color.Gray;
        public Color CellColor
        {
            get { return _CellColor; }
            set
            {
                _CellColor = value;
                OnPropertyChanged("CellColor");
            }
        }

        private bool _CellSecondSwipe = false;
        public bool CellSecondSwipe
        {
            get { return _CellSecondSwipe; }
            set
            {
                _CellSecondSwipe = value;
                OnPropertyChanged("CellSecondSwipe");
            }
        }


        public void BattleOnCell(ref StratCell invadingCell)
        {
            int homeUnits = invadingCell.CellUnits;

            //Only battle if the invadingCell has more than one.
            if(!(homeUnits <= 1))
            {
                //First swipe
                if (!invadingCell.CellSecondSwipe)
                {
                    int invadingUnits = invadingCell.CellUnits / 2;
                    //Attacking Gray
                    if (this.CellColor == Color.Gray)
                    {
                        this.CellColor = invadingCell.CellColor;
                        this.CellUnits = invadingUnits;
                        invadingCell.CellUnits = homeUnits - invadingUnits;
                    }
                    //Attacking same color
                    else if(this.CellColor == invadingCell.CellColor)
                    {
                        this.CellUnits = this.CellUnits + invadingUnits;
                        invadingCell.CellUnits = homeUnits - invadingUnits;
                    }
                    //Attacking opposing color
                    else
                    {
                        //Invading is larger
                        if (invadingUnits > this.CellUnits)
                        {
                            this.CellColor = invadingCell.CellColor;
                            this.CellUnits = invadingUnits - this.CellUnits;
                            invadingCell.CellUnits = homeUnits - invadingUnits;
                        }
                        //Invading is smaller
                        else if(invadingUnits < this.CellUnits)
                        {
                            this.CellUnits = this.CellUnits - invadingUnits;
                            invadingCell.CellUnits = homeUnits - invadingUnits;
                        }
                        //Invading is equal
                        else
                        {
                            Random rand = new Random();
                            //Invading wins
                            if(rand.Next() % 2 == 0)
                            {
                                this.CellColor = invadingCell.CellColor;
                                this.CellUnits = 1;
                                invadingCell.CellUnits = homeUnits - invadingUnits;
                            }
                            //Invading loses
                            else
                            {
                                this.CellUnits = 1;
                                invadingCell.CellUnits = homeUnits - invadingUnits;
                            }
                        }
                    }

                    invadingCell.CellSecondSwipe = true;
                }
                //Second swipe
                else
                {
                    int invadingUnits = homeUnits - 1;

                    //Attacking Gray
                    if (this.CellColor == Color.Gray)
                    {
                        this.CellColor = invadingCell.CellColor;
                        this.CellUnits = invadingUnits;
                        invadingCell.CellUnits = 1;
                    }
                    //Attacking same color
                    else if (this.CellColor == invadingCell.CellColor)
                    {
                        this.CellUnits = this.CellUnits + invadingUnits;
                        invadingCell.CellUnits = 1;
                    }
                    //Attacking opposing color
                    else
                    {
                        //Invading is larger
                        if (invadingUnits > this.CellUnits)
                        {
                            this.CellColor = invadingCell.CellColor;
                            this.CellUnits = invadingUnits - this.CellUnits;
                            invadingCell.CellUnits = 1;
                        }
                        //Invading is smaller
                        else if (invadingUnits < this.CellUnits)
                        {
                            this.CellUnits = this.CellUnits - invadingUnits;
                            invadingCell.CellUnits = 1;
                        }
                        //Invading is equal
                        else
                        {
                            Random rand = new Random();
                            //Invading wins
                            if (rand.Next() % 2 == 0)
                            {
                                this.CellColor = invadingCell.CellColor;
                                this.CellUnits = 1;
                                invadingCell.CellUnits = 1;
                            }
                            //Invading loses
                            else
                            {
                                this.CellUnits = 1;
                                invadingCell.CellUnits = 1;
                            }
                        }
                    }
                }
            }
            else
            {
                Debug.WriteLine("Too few units to invade");
            }
        }

        public void TurnIncrease()
        {
            if(CellColor != Color.Gray)
            {
                CellUnits += 1;
                CellSecondSwipe = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
