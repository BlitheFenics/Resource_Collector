using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    Grid grid;
    public Text Resources, Counter, Scanner, Toggle, Scanned;
    public int value, counter = 3, scanner = 6, toggle = 0, score1, score2, score3, totalScore;
    public bool click = true, leftClick = true, gridOn = false;
    Vector3 mouseX, mouseX2, mouseXY, mouseXY2, mouseY, mouseY2, mouseXY3, mouseXY4, mouseY3, mouseY4, mouseX3, mouseX4, mouseXY5, mouseXY6, mouseXY7, mouseXY8, mouseXY9, mouseXY10, mouseXY11, mouseXY12, mouseXY13, mouseXY14, mouseXY15, mouseXY16;

    private void Update()
    {
        // Alows you to create a grid by pressing 'Q'
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (gridOn != true)
            {
                grid = new Grid(32, 32, 3f, new Vector3(20, 0));
                gridOn = true;
            }
        }

        // makes it so a click sees the mouse position and all necessary adjacent positions
        var mousePos = Input.mousePosition;
        mousePos.z = 85;
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        mouseX.Set(x + 30f, y, 85);
        mouseX2.Set(x + 60f, y, 85);
        mouseY.Set(x, y + 30f, 85);
        mouseY2.Set(x, y + 60f, 85);
        mouseXY.Set(x + 30f, y + 30f, 85);
        mouseXY3.Set(x + 30f, y + 60f, 85);
        mouseXY4.Set(x + 60f, y + 30f, 85);
        mouseXY2.Set(x + 60f, y + 60f, 85);
        mouseY3.Set(x, y - 30f, 85);
        mouseY4.Set(x, y - 60f, 85);
        mouseX3.Set(x - 30f, y, 85);
        mouseX4.Set(x - 60f, y, 85);
        mouseXY5.Set(x - 30f, y - 30f, 85);
        mouseXY6.Set(x - 60f, y - 60f, 85);
        mouseXY7.Set(x - 60f, y - 30f, 85);
        mouseXY8.Set(x - 30f, y - 60f, 85);
        mouseXY9.Set(x - 30f, y + 30f, 85);
        mouseXY10.Set(x - 30f, y + 60f, 85);
        mouseXY11.Set(x - 60f, y + 30f, 85);
        mouseXY12.Set(x - 60f, y + 60f, 85);
        mouseXY13.Set(x + 30f, y - 30f, 85);
        mouseXY14.Set(x + 30f, y - 60f, 85);
        mouseXY15.Set(x + 60f, y - 30f, 85);
        mouseXY16.Set(x + 60f, y - 60f, 85);

        // Allows you to switch between Extract mode and Scan mode
        if (Input.GetKeyDown(KeyCode.E))
        {
            toggle = 0;
            Toggle.text = "Toggle Mode: Extract";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            toggle = 1;
            Toggle.text = "Toggle Mode: Scan";
        }

        if (toggle == 0)
        {
            if (click == true)
            {
                
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));

                    // get the values of 25 tiles starting from the center and then the adjacent ones
                    int val = grid.GetValue(Camera.main.ScreenToWorldPoint(mousePos));
                    int val2 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseX));
                    int val3 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseX2));
                    int val4 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseY));
                    int val5 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseY2));
                    int val6 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY));
                    int val7 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY3));
                    int val8 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY4));
                    int val9 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY2));
                    int val0 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseY3));
                    int val10 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseY4));
                    int val11 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseX3));
                    int val12 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseX4));
                    int val13 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY5));
                    int val14 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY6));
                    int val15 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY7));
                    int val16 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY8));
                    int val17 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY9));
                    int val18 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY10));
                    int val19 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY11));
                    int val20 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY12));
                    int val21 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY13));
                    int val22 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY14));
                    int val23 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY15));
                    int val24 = grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY16));

                    // Lowers the value of the 25 tiles by 10 points
                    if (val > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mousePos), val - 10);
                    if (val2 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseX), val2 - 10);
                    if (val3 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseX2), val3 - 10);
                    if (val4 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseY), val4 - 10);
                    if (val5 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseY2), val5 - 10);
                    if (val6 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY), val6 - 10);
                    if (val7 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY3), val7 - 10);
                    if (val8 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY4), val8 - 10);
                    if (val9 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY2), val9 - 10);
                    if (val0 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseY3), val0 - 10);
                    if (val10 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseY4), val10 - 10);
                    if (val11 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseX3), val11 - 10);
                    if (val12 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseX4), val12 - 10);
                    if (val13 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY5), val13 - 10);
                    if (val14 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY6), val14 - 10);
                    if (val15 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY7), val15 - 10);
                    if (val16 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY8), val16 - 10);
                    if (val17 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY9), val17 - 10);
                    if (val18 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY10), val18 - 10);
                    if (val19 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY11), val19 - 10);
                    if (val20 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY12), val20 - 10);
                    if (val21 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY13), val21 - 10);
                    if (val22 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY14), val22 - 10);
                    if (val23 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY15), val23 - 10);
                    if (val24 > 0)
                        grid.SetValue(Camera.main.ScreenToWorldPoint(mouseXY16), val24 - 10);

                    // Displays the total score of resources collected
                    if (counter == 3)
                    {
                        score1 = (val + val0 + val10 + val11 + val12 + val13 + val14 + val15 + val16 + val17 + val18 + val19 + val2 + val20 + val21 + val22 + val23 + val24 + val3 + val4 + val5 + val6 + val7 + val8 + val9);
                        Resources.text = "Resources Collected " + score1;
                    }
                    if (counter == 2)
                    {
                        score2 = (val + val0 + val10 + val11 + val12 + val13 + val14 + val15 + val16 + val17 + val18 + val19 + val2 + val20 + val21 + val22 + val23 + val24 + val3 + val4 + val5 + val6 + val7 + val8 + val9);
                        totalScore = score1 + score2;
                        Resources.text = "Resources Collected " + totalScore;
                    }
                    if (counter == 1)
                    {
                        score3 = (val + val0 + val10 + val11 + val12 + val13 + val14 + val15 + val16 + val17 + val18 + val19 + val2 + val20 + val21 + val22 + val23 + val24 + val3 + val4 + val5 + val6 + val7 + val8 + val9);
                        totalScore = score1 + score2 + score3;
                        Resources.text = "Resources Collected " + totalScore;
                    }

                    // Lowers how many times the user can clicks and displays total clicks on screen
                    counter--;
                    Counter.text = "Clicks Extract: " + counter;
                    if (counter == 0)
                    {
                        click = false;
                    }
                }
                Debug.Log(counter);
            }
        }

        if (toggle == 1)
        {
            if (leftClick == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // Gets the values of 25 tiles
                    int center = (grid.GetValue(Camera.main.ScreenToWorldPoint(mousePos)));
                    int right = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseX)));
                    int farRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseX2)));
                    int up = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseY)));
                    int farUp = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseY2)));
                    int upRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY)));
                    int farUpRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY3)));
                    int upFarRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY4)));
                    int farUpFarRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY2)));
                    int down = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseY3)));
                    int farDown = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseY4)));
                    int left = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseX3)));
                    int farLeft = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseX4)));
                    int downLeft = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY5)));
                    int farDownFarLeft = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY6)));
                    int downfarLeft = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY7)));
                    int farDownLeft = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY8)));
                    int upLeft = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY9)));
                    int farUpLeft = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY10)));
                    int farLeftUp = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY11)));
                    int farUpFarLeft = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY12)));
                    int downRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY13)));
                    int farDownRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY14)));
                    int downFarRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY15)));
                    int farDownFarRight = (grid.GetValue(Camera.main.ScreenToWorldPoint(mouseXY16)));

                    // Displays the total resources the 35 tiles each have and lowers how many times the user can scan by 1
                    Scanned.text = "Scanned resources: \n center: " + center + "\n right: " + right + "\n farRight: " + farRight + "\n up: " + up + "\n farUp: " + farUp + "\n upRight: " + upRight + "\n farUpRight: " + farUpRight + "\n upFarRight: " + upFarRight + "\n farUpFarRight: " + farUpFarRight + "\n down: " + down + "\n farDown: " + farDown + "\n left: " + left + "\n farLeft: " + farLeft + "\n downLeft: " + downLeft + "\n farDownFarleft: " + farDownFarLeft + "\n downFarLeft: " + downfarLeft + "\n farDownLeft: " + farDownLeft + "\n upLeft: " + upLeft + "\n farUpLeft: " + farUpLeft + "\n farLeftUp: " + farLeftUp + "\n farUpFarLeft: " + farUpFarLeft + "\n downRight: " + downRight + "\n farDownRight: " + farDownRight + "\n downFarRight: " + downFarRight + "\n farDownFarRight: " + farDownFarRight;
                    scanner--;
                    Scanner.text = "Clicks Scanner: " + scanner;
                    if (scanner == 0)
                    {
                        leftClick = false;
                    }
                }
                Debug.Log(scanner);
            }
        }
    }
}