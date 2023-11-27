package com.logger.pluginporte;

public interface AlertCallback {
    public void onPositive(String message);
    public void onNegative(String message);
}
