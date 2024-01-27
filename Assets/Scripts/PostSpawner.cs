using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PostSpawner : SignalReceiver, INotificationReceiver
{
    public static PostSpawner Instance;

    private void Start()
    {
        Instance = this;
    }

    List<Post> posts = new List<Post>();
    public Post NextPost => posts.FirstOrDefault(); 

    public Post SpawnPost(Post post, float speed)
    {
        var spawnedPost = Instantiate(post, transform);
        spawnedPost.Speed = speed;

        posts.Add(spawnedPost);
        return spawnedPost;
    }

    public void RemovePost(Post post)
    {
        posts.Remove(post);
        GameObject.Destroy(post.gameObject);
        //TODO: death anim
    }

    public new void OnNotify(Playable origin, INotification notification, object context)
    {
        if(notification is SpawnSignal postEmitter)
        {
            SpawnPost(postEmitter.Post, postEmitter.Speed);
        }
    }
}
