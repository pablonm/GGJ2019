using UnityEngine;

public class MapTransition : MonoBehaviour
{
    public static void GoTo(string map, string point) {
        GameObject player = FindObjectOfType<PlayerStatus>().gameObject;
        SmoothCamera2D camera = FindObjectOfType<SmoothCamera2D>();
        camera.FadeOutIn(() => {
            player.transform.position = GameObject.Find(map).transform.Find(point).transform.position;
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, camera.transform.position.z);
        });
    }
}
