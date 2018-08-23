using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Saveable<T> {

    T fromJson( string json);
    string toJson<T>( T obj );

}