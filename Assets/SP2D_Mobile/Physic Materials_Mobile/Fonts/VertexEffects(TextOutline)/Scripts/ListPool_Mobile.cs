using System;
using System.Collections.Generic;
using UnityEngine;

static class ListPool_Mobile<T>
{
    // Object pool to avoid allocations.
	private static readonly ObjectPool_Mobile<List<T>> s_ListPool = new ObjectPool_Mobile<List<T>>(null, l => l.Clear());

    public static List<T> Get()
    {
        return s_ListPool.Get();
    }

    public static void Release(List<T> toRelease)
    {
        s_ListPool.Release(toRelease);
    }
}
