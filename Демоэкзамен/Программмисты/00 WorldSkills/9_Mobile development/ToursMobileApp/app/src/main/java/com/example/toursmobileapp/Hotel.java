package com.example.toursmobileapp;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Parcel;
import android.os.Parcelable;
import android.util.Base64;

public class Hotel implements Parcelable {
    private int id;
    private String name;
    private int countOfStars;
    private String imageSource;

    public Hotel(int id, String name, int countOfStars, String imageSource) {
        this.id = id;
        this.name = name;
        this.countOfStars = countOfStars;
        this.imageSource = imageSource;
    }

    protected Hotel(Parcel in) {
        id = in.readInt();
        name = in.readString();
        countOfStars = in.readInt();
        imageSource = in.readString();
    }

    public static final Creator<Hotel> CREATOR = new Creator<Hotel>() {
        @Override
        public Hotel createFromParcel(Parcel in) {
            return new Hotel(in);
        }

        @Override
        public Hotel[] newArray(int size) {
            return new Hotel[size];
        }
    };

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getCountOfStars() {
        return countOfStars;
    }

    public void setCountOfStars(int countOfStars) {
        this.countOfStars = countOfStars;
    }

    public String getImageSource() {
        return imageSource;
    }

    public void setImageSource(String imageSource) {
        this.imageSource = imageSource;
    }

    public Bitmap getBitmapSource(){
        byte[] array = Base64.decode(getImageSource(), Base64.DEFAULT);
        return BitmapFactory.decodeByteArray(array, 0, array.length);
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(id);
        dest.writeString(name);
        dest.writeInt(countOfStars);
        dest.writeString(imageSource);
    }
}