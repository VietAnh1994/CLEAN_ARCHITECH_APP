﻿namespace App.Domain.Events
{
    public class UserUpdatedEvent
    {
        public int Id { get; }
        public string NewEmail { get; }

        public UserUpdatedEvent(int userId, string newEmail)
        {
            Id = userId;
            NewEmail = newEmail;
        }
    }
}
