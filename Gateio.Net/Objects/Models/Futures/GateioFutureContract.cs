using Newtonsoft.Json;

namespace Gateio.Net.Objects.Models.Futures;

public class GateioFutureContract
{
    /// <summary>
    /// Gets or sets the name of the futures contract.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the futures contract.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the multiplier used in converting from invoicing to settlement currency.
    /// </summary>
    [JsonProperty("quanto_multiplier")]
    public string QuantoMultiplier { get; set; }

    /// <summary>
    /// Gets or sets the minimum leverage.
    /// </summary>
    [JsonProperty("leverage_min")]
    public string LeverageMin { get; set; }

    /// <summary>
    /// Gets or sets the maximum leverage.
    /// </summary>
    [JsonProperty("leverage_max")]
    public string LeverageMax { get; set; }

    /// <summary>
    /// Gets or sets the maintenance rate of margin.
    /// </summary>
    [JsonProperty("maintenance_rate")]
    public string MaintenanceRate { get; set; }

    /// <summary>
    /// Gets or sets the mark price type.
    /// </summary>
    [JsonProperty("mark_type")]
    public string MarkType { get; set; }

    /// <summary>
    /// Gets or sets the current mark price.
    /// </summary>
    [JsonProperty("mark_price")]
    public string MarkPrice { get; set; }

    /// <summary>
    /// Gets or sets the current index price.
    /// </summary>
    [JsonProperty("index_price")]
    public string IndexPrice { get; set; }

    /// <summary>
    /// Gets or sets the last trading price.
    /// </summary>
    [JsonProperty("last")]
    public string LastPrice { get; set; }

    /// <summary>
    /// Gets or sets the maker fee rate, where negative means a rebate.
    /// </summary>
    [JsonProperty("maker_fee_rate")]
    public string MakerFeeRate { get; set; }

    /// <summary>
    /// Gets or sets the taker fee rate.
    /// </summary>
    [JsonProperty("taker_fee_rate")]
    public string TakerFeeRate { get; set; }

    /// <summary>
    /// Gets or sets the minimum order price increment.
    /// </summary>
    [JsonProperty("order_price_round")]
    public string OrderPriceRound { get; set; }

    /// <summary>
    /// Gets or sets the minimum mark price increment.
    /// </summary>
    [JsonProperty("mark_price_round")]
    public string MarkPriceRound { get; set; }

    /// <summary>
    /// Gets or sets the current funding rate.
    /// </summary>
    [JsonProperty("funding_rate")]
    public string FundingRate { get; set; }

    /// <summary>
    /// Gets or sets the funding application interval in seconds.
    /// </summary>
    [JsonProperty("funding_interval")]
    public int FundingInterval { get; set; }

    /// <summary>
    /// Gets or sets the next funding time.
    /// </summary>
    [JsonProperty("funding_next_apply")]
    public double FundingNextApply { get; set; }

    /// <summary>
    /// Gets or sets the risk limit base.
    /// </summary>
    [JsonProperty("risk_limit_base")]
    public string RiskLimitBase { get; set; }

    /// <summary>
    /// Gets or sets the step of adjusting risk limit.
    /// </summary>
    [JsonProperty("risk_limit_step")]
    public string RiskLimitStep { get; set; }

    /// <summary>
    /// Gets or sets the maximum risk limit the contract allowed.
    /// </summary>
    [JsonProperty("risk_limit_max")]
    public string RiskLimitMax { get; set; }

    /// <summary>
    /// Gets or sets the minimum order size the contract allowed.
    /// </summary>
    [JsonProperty("order_size_min")]
    public long OrderSizeMin { get; set; }

    /// <summary>
    /// Gets or sets the maximum order size the contract allowed.
    /// </summary>
    [JsonProperty("order_size_max")]
    public long OrderSizeMax { get; set; }

    /// <summary>
    /// Gets or sets the deviation between the order price and current index price.
    /// </summary>
    [JsonProperty("order_price_deviate")]
    public string OrderPriceDeviate { get; set; }

    /// <summary>
    /// Gets or sets the referral fee rate discount.
    /// </summary>
    [JsonProperty("ref_discount_rate")]
    public string ReferralFeeRateDiscount { get; set; }

    /// <summary>
    /// Gets or sets the referrer commission rate.
    /// </summary>
    [JsonProperty("ref_rebate_rate")]
    public string ReferrerCommissionRate { get; set; }

    /// <summary>
    /// Gets or sets the current orderbook ID.
    /// </summary>
    [JsonProperty("orderbook_id")]
    public long OrderbookId { get; set; }

    /// <summary>
    /// Gets or sets the current trade ID.
    /// </summary>
    [JsonProperty("trade_id")]
    public long TradeId { get; set; }

    /// <summary>
    /// Gets or sets the historical accumulated trade size.
    /// </summary>
    [JsonProperty("trade_size")]
    public long TradeSize { get; set; }

    /// <summary>
    /// Gets or sets the current total long position size.
    /// </summary>
    [JsonProperty("position_size")]
    public long PositionSize { get; set; }

    /// <summary>
    /// Gets or sets the last changed time of configuration.
    /// </summary>
    [JsonProperty("config_change_time")]
    public double ConfigChangeTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the contract is delisting.
    /// </summary>
    [JsonProperty("in_delisting")]
    public bool InDelisting { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of open orders.
    /// </summary>
    [JsonProperty("orders_limit")]
    public int OrdersLimit { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the bonus is enabled.
    /// </summary>
    [JsonProperty("enable_bonus")]
    public bool EnableBonus { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether portfolio margin account is enabled.
    /// </summary>
    [JsonProperty("enable_credit")]
    public bool EnableCredit { get; set; }

    /// <summary>
    /// Gets or sets the created time of the contract.
    /// </summary>
    [JsonProperty("create_time")]
    public double CreateTime { get; set; }
}