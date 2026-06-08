using System.ComponentModel.DataAnnotations;
using AVcontrol;
using Microsoft.EntityFrameworkCore;



namespace MessengerServer
{
    // jabaNetPassword

    /*
    * File.db
    *      Users                           (table) 
    *          SUID        (UInt64)[key]
    *          Name        (VRCHAR(40))
    *          Surname     (VRCHAR(40))
    *          Bio         (VRCHAR(120))
    *          Avatar      (VRCHAR(150))       это путь до файла
    *
    *      UserDevices                     (table)
    *          userSUID    (UInt64)[key]
    *          deviceID    (UInt16)
    *          sessionID   (UInt64)
    *          isSynced    (Bool)
    *
    *      Messages                        (table)
    *          SUID        (UInt64)[key]
    *          Time        (TIME)
    *          Owner       (UInt64)            это SUID отправителя
    *          Membership  (UInt64)            это SUID чата, в котором лежит месага
    *          TypeMessage (enum file/pic/music/. . .)
    *          Content     (nullable TEXT)      путь до файла/текст сообщения (зависит от типа)
    *      
    *      Chats                           (table)
    *          SUID        (UInt64)[key]
    *          Name        (VRCHAR(40))
    *          Bio         (VRCHAR(120))
    *          Avatar      (VRCHAR(150))
    *      
    *      Participants                    (table)
    *          rID         (primary key)
    *          UserSUID    (UInt64)
    *          ChatSUID    (UInt64)
    *          UserRole    (Uint8)            банальным enum мы обозначим роли как цифры (вледлец-0, админ-1, участник-2, читатель-3) - что то вроде такого
    */

    public class User
    {
        [Key]
        public UInt64 SUID { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(40)]
        public string Surname { get; set; }
        [MaxLength(120)]
        public string Bio { get; set; }
        [MaxLength(150)]
        public string Avatar { get; set; }
    }

    [PrimaryKey(nameof(UserSUID), nameof(deviceID), nameof(sessionID))]
    public class UserDevices
    {
        public UInt64 UserSUID { get; set; }
        public byte deviceID { get; set; }
        public UInt64 sessionID { get; set; }
        public bool isSynced { get; set; }
    }

    public class Message
    {
        [Key]
        public UInt64 SUID { get; set; }
        public DateTime Time { get; set; }
        public UInt64 Owner { get; set; }
        public UInt64 Membership { get; set; }
        public Type type { get; set; }
        public string? Content { get; set; }

        public enum Type
        {
            text,
            file,           // потом добавим войс
        }
    }

    public class Chat
    {
        [Key]
        public UInt64 SUID { get; set; }
        public UInt64 OwnerSUID { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(120)]
        public string Bio { get; set; }
        [MaxLength(150)]
        public string Avatar { get; set; }
    }

    [PrimaryKey(nameof(UserSUID), nameof(ChatSUID))]
    public class Participant
    {
        public UInt64 UserSUID { get; set; }
        public UInt64 ChatSUID { get; set; }
        public Type UserRole { get; set; }

        public enum Type
        {
            admin,
            participant,
            observer,
        }
    }
}
