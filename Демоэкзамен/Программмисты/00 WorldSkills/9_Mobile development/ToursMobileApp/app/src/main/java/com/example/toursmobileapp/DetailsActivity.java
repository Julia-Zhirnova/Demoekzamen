package com.example.toursmobileapp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.RatingBar;
import android.widget.TextView;

public class DetailsActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_details);

        Hotel currentHotel = getIntent().getParcelableExtra("hotel");
        ImageView imgPhoto = findViewById(R.id.imageViewDetailsPhoto);
        TextView txtName = findViewById(R.id.textViewDetailsName);
        RatingBar rtStars = findViewById(R.id.ratingBarDetailsStars);

        imgPhoto.setImageBitmap(currentHotel.getBitmapSource());
        txtName.setText(currentHotel.getName());
        rtStars.setRating(currentHotel.getCountOfStars());
    }
}