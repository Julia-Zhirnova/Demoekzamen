<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "orders".
 *
 * @property int $id
 * @property string $date
 * @property string $contact
 * @property string $content
 * @property float $price
 */
class Order extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'orders';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['date'], 'safe'],
            [['contact', 'content', 'price'], 'required'],
            [['content'], 'string'],
            [['price'], 'number'],
            [['contact'], 'string', 'max' => 255],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'date' => 'Дата',
            'contact' => 'Контакты',
            'content' => 'Содержимое заказа',
            'price' => 'Итоговая стоимость',
        ];
    }
}
