package com.movesense.samples.sensorsample;

/**
 * Created by saad-pc on 11/25/2018.
 */
import com.google.gson.annotations.SerializedName;

public class TempResponse {

    @SerializedName("Body")
    public final TempResponse.Body body;
    public TempResponse(TempResponse.Body body) {
        this.body = body;
    }

    public static class Body {
        @SerializedName("Timestamp")
        public final long timestamp;

        @SerializedName("ArrayAcc")
        public final AccDataResponse.Array[] array;

        @SerializedName("Headers")
        public final AccDataResponse.Headers header;

        public Body(long timestamp, AccDataResponse.Array[] array, AccDataResponse.Headers header) {
            this.timestamp = timestamp;
            this.array = array;
            this.header = header;
        }
    }


}
