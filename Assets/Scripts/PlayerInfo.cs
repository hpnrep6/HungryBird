using System.Collections;
using System.Collections.Generic;
public class PlayerInfo {
    private static float playerSize = 3f; // default starting size

    public static void setPlayerSize(float size) {
        playerSize = size;
    }

    public static float getPlayerSize() {
        return playerSize;
    }
}
