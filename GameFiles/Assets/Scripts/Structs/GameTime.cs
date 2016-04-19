using UnityEngine;
using System.Collections;
using System;

public struct GameTime {
    public int Days;
    public float Seconds;
    public float Minutes;
    public float Hours;

    public GameTime(float h, float min, float sec, int d) {
        if(h > 23 || min > 59 || sec > 59) {
            throw new ArgumentException("Invalid time specified");
        }
        Hours = h;
        Minutes = min;
        Seconds = sec;
        Days = d;
    }

    public GameTime(float h, float min, float sec) {
        if(h > 23 || min > 59 || sec > 59) {
            throw new ArgumentException("Invalid time specified");
        }
        Hours = h;
        Minutes = min;
        Seconds = sec;
        Days = 0;
    }

    public GameTime(float h, float min) {
        if(h > 23 || min > 59) {
            throw new ArgumentException("Invalid time specified");
        }
        Hours = h;
        Minutes = min;
        Seconds = .0f;
        Days = 0;
    }

    public GameTime(float h) {
        if(h > 23) {
            throw new ArgumentException("Invalid time specified");
        }
        Hours = h;
        Minutes = .0f;
        Seconds = .0f;
        Days = 0;
    }

    public override string ToString() {
        return Hours + ":" + Minutes + ":" + Seconds;
    }
    //TODO: In code its updating every frame
    public void AddHours(uint h) {
        this.Hours += (int)h;
        if(this.Hours > 23) {
            this.Hours -= 23;
            this.Days += 1;
        }
    }

    public void AddMinutes(uint m) {
        this.Minutes += (int)m;
        if(this.Minutes > 59) {
            this.Minutes -= 59;
            this.Hours += 1;
        }
    }

    public void AddSeconds(uint s) {
        this.Seconds += (int)s;
        if(this.Seconds > 59) {
            this.Seconds -= 59;
            this.Minutes += 1;

        }
    }

    public void UpdateTime() {

        if(this.Seconds > 59) {
            this.Seconds -= 60;
            this.Minutes += 1;
        }
        if(this.Minutes > 59) {
            this.Minutes -= 60;
            this.Hours += 1;
        }
        if(this.Hours > 23) {
            this.Hours -= 24;
            this.Days += 1;
        }
    }
}
