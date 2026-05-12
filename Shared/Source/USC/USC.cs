using System;



namespace Shared.Source.USC
{
    public enum MainCommand : Byte
    {
        CONNECT_CLIENT_SERVER_1_EN = 0,
        CONNECT_CLIENT_SERVER_2_EE = 1,
        CONNECT_CLIENT_SERVER_3_NE = 2,

        CONNECT_CLIENT_CLIENT_1_EN = 3,
        CONNECT_CLIENT_CLIENT_2_EE = 4,
        CONNECT_CLIENT_CLIENT_3_NE = 5,

        STD_AUTHENTICATION   = 6,
        TOKEN_AUTHENTICATION = 7,

        HERE_IS_SYNC    = 8,
        I_RECEIVED_SYNC = 9,
        TRY_CHANGE_MY_DEVICE_PRIORITY = 10,

        GET_ACTIVE_CHATS    = 11,
        UPDATE_CHAT_HISTORY = 12,

        PING_STATUS_CHECK = 13,
        MESSAGE_RECEIVED  = 14,
        MESSAGE_READ      = 15,

        SEND_MSG   = 16,
        SEND_PIC   = 17,
        SEND_FILE  = 18,
        SEND_MUSIC = 19,
        DELETE_MSG = 20,

        CHANGE_LOGIN    = 21,
        CHANGE_PASSWORD = 22,
        DELETE_ACCOUNT  = 23,

        UNKNOWN = 255
    }



    public enum SubCommand : Byte
    {
        NONE = 0,

        SERVER_HERE_IS_NEW_EKEY = 1,
        SERVER_HERE_IS_NEW_EKEY_PR_ALPHABET = 2,
        SERVER_HERE_IS_NEW_EKEY_EX_ALPHABET = 3,
        SERVER_HERE_IS_NEW_EKEY_SHIFTS = 4,

        CLIENT_FROM_SERVER_HERE_IS_NEW_EKEY = 5,
        CLIENT_FROM_SERVER_HERE_IS_NEW_EKEY_PR_ALPHABET = 6,
        CLIENT_FROM_SERVER_HERE_IS_NEW_EKEY_EX_ALPHABET = 7,
        CLIENT_FROM_SERVER_HERE_IS_NEW_EKEY_SHIFTS = 8,

        CLIENT_HERE_IS_NEW_EKEY = 9,
        CLIENT_HERE_IS_NEW_EKEY_PR_ALPHABET = 10,
        CLIENT_HERE_IS_NEW_EKEY_EX_ALPHABET = 11,
        CLIENT_HERE_IS_NEW_EKEY_SHIFTS = 12,

        SWITCH_MY_SESSION_ID_TO_NEW_AND_SEND_IT_BACK = 13,

        UNKNOWN = 255
    }



    public enum Response : Byte
    {
        OK = 0,
        OK_NOW_SYNCING = 1,

        NOT_NOW_PLEASE_WAIT_FOR_SYNC = 2,

        ERROR_UNKNOWN = 3,
        ERROR_PROBABLY_INTERNET_TROUBLE = 4,
        ERROR_YOU_NEED_TO_REAUTHORISE = 5
    }
}