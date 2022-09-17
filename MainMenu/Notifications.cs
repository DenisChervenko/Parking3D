using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notifications : MonoBehaviour
{
    private void Awake()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Name = "Notification",
            Description = "Notification of the need to log in to the game",
            Id = "Log in",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        SendNotification();
    }

    private void SendNotification()
    {
        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Have you forgotten about us?",
            Text = "Don't forget to play, it's fun and cool!",
            FireTime = System.DateTime.Now.AddSeconds(7200),
            SmallIcon = "small_icon",
            LargeIcon = "large_icon"
        };

        AndroidNotificationCenter.SendNotification(notification, "Log in");
    }
}